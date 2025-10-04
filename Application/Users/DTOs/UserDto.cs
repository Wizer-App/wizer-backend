namespace Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Photo { get; set; }
    public string? TypeUser { get; set; }
    public int? InfoUserId { get; set; }
}