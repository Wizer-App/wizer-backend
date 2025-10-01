using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<User>>
{
    public GetAllUsersQuery()
    {

    }
}