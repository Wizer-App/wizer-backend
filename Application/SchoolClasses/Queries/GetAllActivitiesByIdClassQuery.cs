using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;

public class GetAllActivitiesByIdClassQuery : IRequest<IEnumerable<Activity>>
{
    public int ClassId { get; }
    
    public GetAllActivitiesByIdClassQuery(int classId)
    {
        ClassId = classId;
    }
}