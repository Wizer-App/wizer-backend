using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class AddSchoolClassCommand :IRequest<SchoolClassDto>
{
    public SchoolClassDto SchoolClass { get; }
    
    public AddSchoolClassCommand(SchoolClassDto schoolClass)
    {
        SchoolClass = schoolClass;
    }
}