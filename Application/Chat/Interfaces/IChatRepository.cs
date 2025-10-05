using Domain.Entities;

namespace Application.Chat.Interfaces;

public interface IChatRepository
{
    Task<Message> SendMessageAsync(Message message);
    Task<IEnumerable<Message>> GetMessagesBySchoolClassIdAsync(int schoolClassId, int page, int pageSize);
    Task<IEnumerable<Message>> GetMessagesByTeamIdAsync(int teamId, int page, int pageSize);
}