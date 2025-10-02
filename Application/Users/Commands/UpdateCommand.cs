using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class UpdateCommand : IRequest<UserDto>
{
    public UserDto User { get; }

    public UpdateCommand(UserDto user)
    {
        User = user;
    }
}