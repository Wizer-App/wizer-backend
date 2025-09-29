namespace Domain.Entities;

public class SchoolClass
{
    // Estas son las columnas de la tabla que se creara 
    // string.Empy para que no puedan ser nulos
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int TeacherId { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string JoinCode { get; private set; } = string.Empty;
    // Esto para la Fk de Techer ID
    public User Teacher { get; set; } = null!;
    //Esto de aca son las relaciones creara una tabla por cada una de estas para relacionarlas esto para acceder mas facilmete a todo eso
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<User> Students { get; set; } = new List<User>(); 
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    
    //metodo generar el codigo 
    public void GenerateJoinCode()
    {
        JoinCode = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
    }
}
