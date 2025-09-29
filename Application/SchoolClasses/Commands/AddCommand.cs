using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class AddCommand :IRequest<SchoolClass>
{
    public SchoolClass SchoolClass { get; }
    
    public AddCommand(SchoolClass schoolClass)
    {
        SchoolClass = schoolClass;
    }
}