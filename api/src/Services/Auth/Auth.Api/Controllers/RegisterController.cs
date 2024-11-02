using Auth.Api.Controllers.Base;
using Auth.Application.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[Route("api/auth/register")]
public class RegisterController : AuthBaseController
{
    private readonly IMediator _mediator;

    public RegisterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        await _mediator.Send(command);
        return Ok("TEST");
    }
}
