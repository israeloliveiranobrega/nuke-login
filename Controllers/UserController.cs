using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NukeLogin.Src.Features.AccessControl.Login;
using NukeLogin.Src.Features.AccessControl.Register;
using NukeLogin.Src.Shared.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NukeLogin.Controllers;

[ApiController]
[Route("nukepay/authentication")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand userCommand)
    {
        var response = await _mediator.Send(userCommand);

        if(!response.IsSuccess)
            return BadRequest(response.ErrorMessage);

        return CreatedAtAction(nameof(Register), new { id = response.Value.UserId }, response.Value.UserId);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest userRequest, [FromServices] IUserAgentServices userAgent)
    {
        var userAgentInfo = await userAgent.Track(Request.Headers.UserAgent.ToString());

        var response = await _mediator.Send(new LoginUserCommand(userRequest, userAgentInfo));

        if (!response.IsSuccess)
            return BadRequest(response.ErrorMessage);

        return Ok(response.Value);
    }
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] LoginUserCommand userCommand)
    {
        var response = await _mediator.Send(userCommand);

        if (!response.IsSuccess)
            return BadRequest(response.ErrorMessage);

        return Ok(response.Value);
    }
}
