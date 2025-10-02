using Application.DTOs;
using Application.Users.Commands;
using Application.Users.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetByIdQuery(id));
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result));
        return Ok(result);
    }

    [HttpGet("user/{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var result = await _mediator.Send(new GetByUsernameQuery(username));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserDto userDto)
    {
        var result = await _mediator.Send(new AddCommand(userDto));
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserDto userDto)
    {
        var result = await _mediator.Send(new UpdateCommand(userDto));
        return Ok(result);
    }

    // para probar si va bien
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }
}