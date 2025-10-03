using Application.DTOs;
using MediatR;

namespace Application.Users.Commands;

public class AddCommand : IRequest<UserDto>
{
    public UserDto UserDto { get; }

    public AddCommand(UserDto userDto)
    {
        UserDto = userDto;
    }
}