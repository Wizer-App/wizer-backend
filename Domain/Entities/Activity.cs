namespace Domain.Entities;

public class Activity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
    public int SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;
    public ICollection<Document> Documents { get; set; } = new List<Document>();
}