using Application.DTOs;
using MediatR;

namespace Application.Users.Queries;

public class GetByUsernameQuery : IRequest<UserDto>
{
    public string Username { get; }

    public GetByUsernameQuery(string username)
    {
        Username = username;
    }
}