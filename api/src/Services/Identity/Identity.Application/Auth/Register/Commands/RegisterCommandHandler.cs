using Identity.Application.Shared.Dtos;
using UpWatch.MediatR.Command;

namespace Identity.Application.Auth.Register.Commands;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, UserDto>
{
    public RegisterCommandHandler()
    {
    }

    public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
