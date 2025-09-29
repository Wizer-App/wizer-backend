namespace Domain.Entities;

public class Team
{
    //Agregar aqui no borrar lo que ya esta
    public int SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;
}