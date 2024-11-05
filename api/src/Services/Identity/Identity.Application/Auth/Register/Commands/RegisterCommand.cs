using Identity.Application.Shared.Dtos;
using UpWatch.MediatR.Command;

namespace Identity.Application.Auth.Register.Commands;

public class RegisterCommand : ICommand<UserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
