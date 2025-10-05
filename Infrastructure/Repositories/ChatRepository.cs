using Application.Chat.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly AppDbContext _context;

    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Message> SendMessageAsync(Message message)
    {
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();
        return await _context.Messages
            .Include(m => m.Sender)
            .Include(m => m.SchoolClass)
            .Include(m => m.Team)
            .FirstOrDefaultAsync(m => m.Id == message.Id) ?? message;
    }

    public async Task<IEnumerable<Message>> GetMessagesBySchoolClassIdAsync(int schoolClassId, int page, int pageSize)
    {
        return await _context.Messages
            .Where(m => m.SchoolClassId == schoolClassId)
            .OrderByDescending(m => m.SentAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(m => m.Sender)
            .Include(m => m.SchoolClass)
            .ToListAsync();
    }

    public async Task<IEnumerable<Message>> GetMessagesByTeamIdAsync(int teamId, int page, int pageSize)
    {
        return await _context.Messages
            .Where(m => m.TeamId == teamId)
            .OrderByDescending(m => m.SentAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(m => m.Sender)
            .Include(m => m.Team)
            .ToListAsync();
    }
}