namespace Application.Chat.Dtos;

public class SendMessageRequestDto
{
    public string Content { get; set; } = string.Empty;
    public int? SchoolClassId { get; set; }
    public int? TeamId { get; set; }
    public int SenderId { get; set; }
}