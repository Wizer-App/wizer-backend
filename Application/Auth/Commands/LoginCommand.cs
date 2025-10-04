using Application.DTOs;
using MediatR;

namespace Application.Auth.Commands;

public class LoginCommand : IRequest<AuthResponseDto>
{
    public LoginDto LoginDto { get; }

    public LoginCommand(LoginDto loginDto)
    {
        LoginDto = loginDto;
    }
}