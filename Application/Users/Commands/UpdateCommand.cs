using Application.DTOs;
using MediatR;

namespace Application.Users.Commands;

public class UpdateCommand : IRequest<UserDto>
{
    public int UserId { get; }
    public UpdateUserDto UpdateUser { get; }

    public UpdateCommand(int userId, UpdateUserDto updateUser)
    {
        UserId = userId;
        UpdateUser = updateUser;
    }
}