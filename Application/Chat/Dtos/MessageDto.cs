using Application.DTOs;
using Domain.Entities;

namespace Application.Chat.Dtos;

public class MessageDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }
    
    public SchoolClassDto? SchoolClass { get; set; }
    public TeamDto? Team { get; set; }
    public required UserDto Sender { get; set; }
}