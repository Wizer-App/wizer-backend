namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string TypeUser { get; set; } = string.Empty;
    public InfoUser InfoUser { get; set; } = null!;
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
