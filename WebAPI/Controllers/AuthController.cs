using Application.DTOs;
using Application.Auth.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _mediator.Send(new LoginCommand(loginDto));
        return Ok(result);
    }
}