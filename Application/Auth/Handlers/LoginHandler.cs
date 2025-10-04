using Application.Auth.Commands;
using Application.Users.Queries;
using Application.DTOs;
using MediatR;
using Supabase;

public class LoginHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly Client _client;
    private readonly IMediator _mediator;
    public LoginHandler(Client client, IMediator mediator)
    {
        _client = client;
        _mediator = mediator;
    }
    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = request.LoginDto;
            var getUserQuery = new GetByUsernameQuery(response.Username);
            var user = await _mediator.Send(getUserQuery, cancellationToken);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    Message = "Error, Usuario no encontrado",
                    Success = false
                };
            }

            var session = await _client.Auth.SignIn(user.Email, response.Password);
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
        catch (Exception)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Credenciales invalidas"
            };
        }
    }
}