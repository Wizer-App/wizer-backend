using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetAllStudentsQeury : IRequest<IEnumerable<User>>
{
    public GetAllStudentsQeury()
    {

    }
}