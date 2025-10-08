using Application.DTOs;

namespace Application.Interfaces;

public interface IAuthRepository
{
    Task<UserAuthDto> Login(string username, string password);

    //Task<AuthResponseDto> Register(string email, string password, string username, string typeUser);
}