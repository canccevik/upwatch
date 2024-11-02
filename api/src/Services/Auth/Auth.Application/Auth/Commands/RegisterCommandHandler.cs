using UpWatch.MediatR.Command;
using User.Application.Dtos;

namespace Auth.Application.Auth.Commands;

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
