using Application.DTOs;
using MediatR;

namespace Application.Users.Queries;

public class GetByIdQuery : IRequest<UserDto>
{
    public int UserId { get; }

    public GetByIdQuery(int userId)
    {
        UserId = userId;
    }
}