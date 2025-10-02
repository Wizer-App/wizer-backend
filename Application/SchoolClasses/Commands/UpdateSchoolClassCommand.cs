using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class UpdateSchoolClassCommand : IRequest<SchoolClassDto>
{
    public int SchoolClassId { get; }
    public UpdateSchoolClassDto UpdateSchoolClassDto { get;  }
    
    public UpdateSchoolClassCommand(int schoolClassId, UpdateSchoolClassDto updateSchoolClassDto)
    {
        UpdateSchoolClassDto = updateSchoolClassDto;
        SchoolClassId = schoolClassId;
    }
}