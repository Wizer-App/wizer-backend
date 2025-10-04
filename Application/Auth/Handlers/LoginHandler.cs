using System.Linq.Expressions;
using Application.Auth.Commands;
using Application.DTOs;
using MediatR;
using Supabase;

public class LoginHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly Client _client;
    public LoginHandler(Client client)
    {
        _client = client;
    }
    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = request.LoginDto;
            var session = await _client.Auth.SignIn(response.Username, response.Password);
            if (session?.User?.Id == null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Login fallido"
                };
            }
            else
            {
                return new AuthResponseDto
                {
                    UserId = session.User.Id,
                    Username = response.Username,
                    AccessToken = session.AccessToken,
                    Success = true,
                    Message = "Login exitoso"

                };
            }
        }
        catch (Exception e)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = e.Message
            };
        }
    }
}