using Application.DTOs;
using MediatR;

namespace Application.Users.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{
    public GetAllUsersQuery()
    {

    }
}