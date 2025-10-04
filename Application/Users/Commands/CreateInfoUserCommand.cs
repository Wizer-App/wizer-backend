using Application.DTOs;
using MediatR;

namespace Application.Users.Commands;

public class CreateInfoUserCommand : IRequest<InfoUserDto>
{
    public InfoUserDto InfoUserDto { get; }

    public CreateInfoUserCommand(InfoUserDto infoUserDto)
    {
        InfoUserDto = infoUserDto;
    }
}