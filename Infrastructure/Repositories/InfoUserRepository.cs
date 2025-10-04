using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class InfoUserRepository : IInfoUserRepository
{
    private readonly AppDbContext _context;
    public InfoUserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<InfoUser> AddInfoUserAsync(InfoUser infoUser)
    {
        _context.InfoUsers.Add(infoUser);
        await _context.SaveChangesAsync();
        return infoUser;
    }
}