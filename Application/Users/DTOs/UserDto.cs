namespace Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Photo { get; set; } = string.Empty;
    public string TypeUser { get; set; } = string.Empty;
    public int InfoUserId { get; set; }
}