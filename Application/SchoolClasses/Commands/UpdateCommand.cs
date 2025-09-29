using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class UpdateCommand : IRequest<SchoolClass>
{
    public SchoolClass SchoolClass { get;  }
    
    public UpdateCommand(SchoolClass schoolClass)
    {
        SchoolClass = schoolClass;
    }
}