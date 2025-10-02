using Application.DTOs;
using Application.SchoolClasses.Commands;
using Application.SchoolClasses.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace WebAPI.Controllers;

//anotaciones es un controller y su ruta 
[ApiController]
[Route("api/[controller]")]
public class SchoolClassesController : ControllerBase
{
    //inyectar dependencias
    private readonly IMediator _mediator;
    public SchoolClassesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("schoolclass/user/{userId:int}")]
    public async Task<IActionResult> GetAllSchoolClassByUserId(int userId)
    {
        var result = await _mediator.Send(new GetAllSchoolClassByUserIdQuery(userId));
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result));
        return Ok(result);
    }

    [HttpGet("schoolclass/class/{schoolClassId:int}")]
    public async Task<IActionResult> GetById(int schoolClassId)
    {
        var result = await _mediator.Send((new GetSchoolClassByIdQuery(schoolClassId)));
        return Ok(result);
    }

    [HttpPost("schoolclass")]
    public async Task<IActionResult> Add([FromBody] SchoolClassDto schoolClassDto)
    {
        var result = await _mediator.Send(new AddSchoolClassCommand(schoolClassDto));
        
        return Ok(result);
    }

    [HttpPut("schoolclass")]
    public async Task<IActionResult> Update([FromBody] SchoolClass schoolClass)
    {
        var result = await _mediator.Send(new UpdateCommand(schoolClass));
        return Ok(result);
    }

    [HttpDelete("schoolclass/{schoolClassId:int}")]
    public async Task<IActionResult> Delete(int schoolClassId)
    {
        var result = await _mediator.Send(new DeleteCommand(schoolClassId));
        return Ok(result);
    }
    
    //join class
    [HttpPost("schoolclass/Join")]
    public async Task<IActionResult> Join([FromQuery] string joinCode, [FromQuery] int userId)
    {
        var result = await _mediator.Send(new JoinSchoolClassCommand(joinCode, userId));
        return Ok(result);
    }

    [HttpPost("schoolclass/Leave")]
    public async Task<IActionResult> Leave([FromQuery] int classId, [FromQuery] int userId)
    {
        var result = await _mediator.Send(new LeaveSchoolClassCommand(classId, userId));
        return Ok(result);
    }

    [HttpGet("schoolclass/students/{schoolClassId:int}")]
    public async Task<IActionResult> GetStudentsBySchoolClassId(int schoolClassId)
    {
        var result = await _mediator.Send(new GetAllStudentsByIdClassQuery(schoolClassId));
        return Ok(result);
    }

    [HttpGet("schoolclass/teams/{schoolClassId:int}")]
    public async Task<IActionResult> GetTeamsBySchoolClassId(int schoolClassId)
    {
        var result = await _mediator.Send(new GetAllTeamsByIdClassQuery(schoolClassId));
        return Ok(result);
    }

    [HttpGet("schoolclass/activity/{schoolClassId:int}")]
    public async Task<IActionResult> GetActivitiesBySchoolClassId(int schoolClassId)
    {
        var result = await _mediator.Send(new GetAllActivitiesByIdClassQuery(schoolClassId));
        return Ok(result);
    }
    
}