namespace Domain.Entities;

public class Activity
{
    //Agregar aqui no borrar lo que ya esta
    public int SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = null!;
}