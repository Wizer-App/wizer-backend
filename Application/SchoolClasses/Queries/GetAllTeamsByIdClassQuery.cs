using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;

public class GetAllTeamsByIdClassQuery : IRequest<IEnumerable<Team>>
{
    public int ClassId { get; }
    
    public GetAllTeamsByIdClassQuery(int classId)
    {
        ClassId = classId;
    }
}