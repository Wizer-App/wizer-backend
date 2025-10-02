using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class AddCommand : IRequest<UserDto>
{
    public UserDto User { get; }

    public AddCommand(UserDto user)
    {
        User = user;
    }
}