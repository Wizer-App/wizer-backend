using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class AddCommand :IRequest<SchoolClassDto>
{
    public SchoolClassDto SchoolClass { get; }
    
    public AddCommand(SchoolClassDto schoolClass)
    {
        SchoolClass = schoolClass;
    }
}