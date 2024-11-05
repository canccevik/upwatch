using Identity.Api.Controllers.Base;
using Identity.Application.Auth.Register.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[Route("api/auth")]
public class AuthController : IdentityBaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
