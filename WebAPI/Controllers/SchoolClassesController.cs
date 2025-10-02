using Application.DTOs;
using Application.SchoolClasses.Commands;
using Application.SchoolClasses.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace WebAPI.Controllers;

//anotaciones es un controller y su ruta 
[ApiController]
[Route("api/schoolclasses")]
public class SchoolClassesController : ControllerBase
{
    //inyectar dependencias
    private readonly IMediator _mediator;
    public SchoolClassesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSchoolClassByUserId([FromQuery] int userId)
    {
        var result = await _mediator.Send(new GetAllSchoolClassByUserIdQuery(userId));
        return Ok(result);
    }

    [HttpGet("{schoolClassId}")]
    public async Task<IActionResult> GetById(int schoolClassId)
    {
        var result = await _mediator.Send((new GetSchoolClassByIdQuery(schoolClassId)));
        if (result == null){
            return NotFound(new { message = $"Clase con ID {schoolClassId} no encontrada" });  
        }

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] SchoolClassDto schoolClassDto)
    {
        var result = await _mediator.Send(new AddSchoolClassCommand(schoolClassDto));
        
        return CreatedAtAction(
            nameof(GetById), 
            new { schoolClassId = result.Id }, 
            result
        ); 
    }
    
    [HttpPut("{schoolClassId}")]
    public async Task<IActionResult> Update(int schoolClassId, [FromBody] UpdateSchoolClassDto updateSchoolClassDto)

    {
        var result = await _mediator.Send(new UpdateSchoolClassCommand(schoolClassId, updateSchoolClassDto));
        return Ok(result);
    }
    
    [HttpDelete("{schoolClassId}")]
    public async Task<IActionResult> Delete(int schoolClassId)
    {
        var result = await _mediator.Send(new DeleteSchoolClassCommand(schoolClassId));
        return NoContent();
    }
    
    [HttpPost("join")]
    public async Task<IActionResult> Join([FromBody] JoinClassRequest request)
    {
        var result = await _mediator.Send(new JoinSchoolClassCommand(request.JoinCode, request.UserId));
        return Ok(result);
    }
    
    [HttpDelete("{classId}/members/{userId}")]
    public async Task<IActionResult> Leave(int classId, int userId)
    {
        var result = await _mediator.Send(new LeaveSchoolClassCommand(classId, userId));
        return NoContent();
    }
    
    [HttpGet("{schoolClassId}/students")]
    public async Task<IActionResult> GetStudentsBySchoolClassId(int schoolClassId)
    {
        var result = await _mediator.Send(new GetAllStudentsByIdClassQuery(schoolClassId));
        return Ok(result);
    }

    [HttpGet("{schoolClassId}/teams")]
    public async Task<IActionResult> GetTeamsBySchoolClassId(int schoolClassId)
    {
        var result = await _mediator.Send(new GetAllTeamsByIdClassQuery(schoolClassId));
        return Ok(result);
    }

    [HttpGet("{schoolClassId}/activities")]
    public async Task<IActionResult> GetActivitiesBySchoolClassId(int schoolClassId)
    {
        var result = await _mediator.Send(new GetAllActivitiesByIdClassQuery(schoolClassId));
        return Ok(result);
    }
    
}