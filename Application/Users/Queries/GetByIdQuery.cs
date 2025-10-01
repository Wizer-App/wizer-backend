using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetByIdQuery : IRequest<User>
{
    public int UserId { get; }

    public GetByIdQuery(int userId)
    {
        UserId = userId;
    }
}