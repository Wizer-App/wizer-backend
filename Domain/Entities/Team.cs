namespace Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public int CreatorId { get; set; }
    public int SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;
    public User Creator { get; set; } = null!;
    public ICollection<User> Members { get; set; } = new List<User>();
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
}