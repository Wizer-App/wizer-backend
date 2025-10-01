using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetByUsernameQuery : IRequest<User>
{
    public string Username { get; }

    public GetByUsernameQuery(string username)
    {
        Username = username;
    }
}