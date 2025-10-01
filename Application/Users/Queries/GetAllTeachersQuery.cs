using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetAllTeachersQuery : IRequest<IEnumerable<User>>
{
    public GetAllTeachersQuery()
    {

    }
}