using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;

public class GetAllStudentsByIdClassQuery : IRequest<IEnumerable<UserDto>>
{
    public int ClassId { get; }
    
    public GetAllStudentsByIdClassQuery(int classId)
    {
        ClassId = classId;
    }
}