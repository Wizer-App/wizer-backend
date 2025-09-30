namespace Domain.Entities;

public class Document
{
    public int Id { get; set; }
    public string Name { get; set; } =  string.Empty;
    public string Path { get; set; } =  string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long Size { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    
    public int CreatorId { get; set; }
    public User Creator { get; set; } = null!;
    public int ActivityId { get; set; }
    public Activity Activity { get; set; } = null!;
}