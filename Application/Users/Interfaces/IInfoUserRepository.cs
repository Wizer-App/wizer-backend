using Domain.Entities;

namespace Application.Interfaces;

public interface IInfoUserRepository
{
    Task<InfoUser> AddInfoUserAsync(InfoUser infoUser);
}