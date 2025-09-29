namespace Domain.Entities;

public class User
{
    //Agregar aqui no borrar lo que ya esta
    public int Id { get; set; }
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
}
