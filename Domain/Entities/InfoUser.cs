namespace Domain.Entities;

public class InfoUser
{
    public int Id { get; set; }
    public string Career { get; set; } = string.Empty;
    public string? ProfessionalTitle { get; set; }
    public string? Semester { get; set; }
    public string? Tuition { get; set; } = string.Empty;
}