using UpWatch.MediatR.Command;
using User.Application.Dtos;

namespace Auth.Application.Auth.Commands;

public class RegisterCommand : ICommand<UserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
