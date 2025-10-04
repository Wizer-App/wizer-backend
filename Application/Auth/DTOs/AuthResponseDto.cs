namespace Application.DTOs;

public class AuthResponseDto
{
    public string UserId { get; set; } = string.Empty;
    public string? Username { get; set; }
    public string? AccessToken { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
}