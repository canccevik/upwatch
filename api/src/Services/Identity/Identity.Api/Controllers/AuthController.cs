using Identity.Api.Controllers.Base;
using Identity.Application.Auth.Register.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UpWatch.Data.AutoWrapper;

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
    public async Task<ApiResponse> Register([FromBody] RegisterCommand command)
        => new ApiResponse(await _mediator.Send(command));
}
