using Application.DTOs;
using MediatR;

namespace Application.Auth.Commands;

public class RegisterCommand : IRequest<AuthResponseDto>
{
    public RegisterDto RegisterDto { get; }

    public RegisterCommand(RegisterDto registerDto)
    {
        RegisterDto = registerDto;
    }
}