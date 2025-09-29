namespace Application.DTOs;

public class SchoolClassDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string JoinCode { get; set; } = string.Empty;
    public required UserDto Teacher { get; set; }
    
    public List<TeamDto>? Teams { get; set; }
    public List<UserDto>? Students { get; set; }
    public List<ActivityDto>? Activities { get; set; }
}