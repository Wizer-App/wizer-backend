using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class AddSchoolClassCommand :IRequest<SchoolClassDto>
{
    public SchoolClassDto SchoolClassDto { get; }
    
    public AddSchoolClassCommand(SchoolClassDto schoolClassDto)
    {
        SchoolClassDto = schoolClassDto;
    }
}