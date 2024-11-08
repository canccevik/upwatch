using AutoMapper;
using Identity.Application.Auth.Register.Events;
using Identity.Application.Shared.Dtos;
using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using UpWatch.Data.AutoWrapper;
using UpWatch.MediatR.Command;

namespace Identity.Application.Auth.Register.Commands;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, UserDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IUserRepository userRepository,
        IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUserWithEmail = await _userManager.FindByEmailAsync(request.Email);
        if (existingUserWithEmail != null)
        {
            throw new ApiException("Email is already taken.");
        }

        var user = _mapper.Map<ApplicationUser>(request);
        user.UserName = request.Email;

        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            var errorMessages = result.Errors.Select(e => e.Description);
            throw new ApiException(errorMessages);
        }

        var createdUser = await _userRepository.FirstOrDefaultAsync(user => user.Email == request.Email);

        await _publishEndpoint.Publish<UserCreatedEvent>(new
        {
            createdUser.Id,
            createdUser.Email
        }, cancellationToken);

        return _mapper.Map<UserDto>(createdUser);
    }
}
