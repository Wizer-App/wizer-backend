using Application.Auth.Commands;
using Application.DTOs;
using MediatR;
using Supabase;
using Application.Interfaces;

public class LoginHandler : IRequestHandler<LoginCommand, UserAuthDto>
{
    public readonly IAuthRepository _repository;
    public LoginHandler(IAuthRepository repository)
    {
        _repository = repository;
    }
    public async Task<UserAuthDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
         try
        {
            var loginDto = request.LoginDto;
            // LLamamos al login del repository
            var userAuth = await _repository.Login(loginDto.Username, loginDto.Password);
            return userAuth;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error en login: {ex.Message}");
        }
    }
}