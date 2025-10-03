using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;

public class GetAllTeamsByIdClassQuery : IRequest<IEnumerable<TeamDto>>
{
    public int ClassId { get; }
    
    public GetAllTeamsByIdClassQuery(int classId)
    {
        ClassId = classId;
    }
}