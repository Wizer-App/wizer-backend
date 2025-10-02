using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class UpdateCommand : IRequest<SchoolClassDto>
{
    public SchoolClassDto SchoolClassDto { get;  }
    
    public UpdateCommand(SchoolClassDto schoolClassDto)
    {
        SchoolClassDto = schoolClassDto;
    }
}