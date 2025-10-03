using Application.DTOs;
using MediatR;

namespace Application.Users.Queries;

public class GetAllTeachersQuery : IRequest<IEnumerable<UserDto>>
{
    public GetAllTeachersQuery()
    {
        
    }
}