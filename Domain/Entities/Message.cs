namespace Domain.Entities;

public class Message
{ 
    public int Id { get; set; }
    public int SchoolClassId { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.Now;
    public int? TeamId { get; set; }

    public SchoolClass SchoolClass { get; set; } = null!;
    public User Sender { get; set; } = null!;
    public Team? Team { get; set; }
}