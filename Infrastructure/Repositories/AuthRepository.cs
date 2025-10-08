using Application.DTOs;
using Application.Interfaces;
using Supabase;

namespace Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly Client _client;
    private readonly IUserRepository _userRepository;

    public AuthRepository(Client client, IUserRepository userRepository)
    {
        _client = client;
        _userRepository = userRepository;
    }
    // AQUI BUSCO EL USUARIO Y LUEGO LO RETORNO
    public async Task<UserAuthDto> Login(string username, string password)
    {
        // Obtengo al user sin token (normal)
        var userAll = await _userRepository.GetByUsernameAsync(username);
        // Inicio sesion ya usando el email
        var session = await _client.Auth.SignIn(userAll.Email, password);
        return new UserAuthDto
        {
            Id = userAll.Id,
            Username = userAll.Username,
            Email = userAll.Email,
            Name = userAll.Name,
            LastName = userAll.LastName,
            CreatedAt = userAll.Created,
            Photo = userAll.Photo,
            TypeUser = userAll.TypeUser,
            InfoUserId = userAll.InfoUserId,
            AccessToken = session.AccessToken
        };
    }
}