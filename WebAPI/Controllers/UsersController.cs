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

    [HttpGet("{id}")]
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
        Console.WriteLine("Antes de agregar");
        var result = await _mediator.Send(new AddCommand(userDto));
        Console.WriteLine("Si agrego");
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserDto userDto)
    {
        var result = await _mediator.Send(new UpdateCommand(userDto));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var resutl = await _mediator.Send(new DeleteCommand(id));
        return Ok(resutl);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }

    [HttpGet("teachers")]
    public async Task<IActionResult> GetAllTeachers()
    {
        var result = await _mediator.Send(new GetAllTeachersQuery());
        return Ok(result);
    }

    [HttpGet("students")]
    public async Task<IActionResult> GetAllStudents()
    {
        var result = await _mediator.Send(new GetAllStudentsQuery());
        return Ok(result);
    }
}