namespace Domain.Entities;

public class Activity
{
    //Agregar aqui no borrar lo que ya esta
    public int? TeamId { get; set; } 
    public Team? Team { get; set; }
    public int SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;
}