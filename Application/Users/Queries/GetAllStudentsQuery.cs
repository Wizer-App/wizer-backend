using Application.DTOs;
using MediatR;

namespace Application.Users.Queries;

public class GetAllStudentsQuery : IRequest<IEnumerable<UserDto>>
{
    public GetAllStudentsQuery()
    {
        
    }
}