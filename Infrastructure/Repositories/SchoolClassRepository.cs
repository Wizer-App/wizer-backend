using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
// implementa la interfaz
// le das en que te cree lo que fata ya que te obliga la interfaz
public class SchoolClassRepository : ISchoolClassRepository
{
    //inyectas el contexto de la db
    private readonly AppDbContext _context;
    public SchoolClassRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<SchoolClass>> GetAllSchoolClassByUserIdAsync(int userId)
    {
        //cada include es una relacion ocupalo para fk y para las listas o colecciones
        // sc => es solo abrebiatura 
        return await _context.SchoolClasses
                //indica que eso corresponde al tecaher
            .Include(sc => sc.Teacher)
            .Include(sc => sc.Students)
            .Include(sc => sc.Teams)
            .Include(sc => sc.Activities)
                // es como SQL busca el los estudiantes si exyeste almenos uno(any) que su id sea el que pasamos
            .Where(sc => sc.TeacherId == userId)
                //lo devuelve como lista 
            .ToListAsync();
    }

    public async Task<SchoolClass?> GetByIdAsync(int id)
    {
        return await _context.SchoolClasses
            .Include(sc => sc.Teacher)
            .Include(sc => sc.Students)
            .Include(sc => sc.Teams)
            .Include(sc => sc.Activities)
            // Busca el primer registro que cumpla la condición
            .FirstOrDefaultAsync(sc => sc.Id == id);
    }

    public async Task<SchoolClass> AddAsync(SchoolClass schoolClass)
    {
        //si no tiene codigo genera uno
        if (string.IsNullOrEmpty(schoolClass.JoinCode))
        {
            schoolClass.GenerateJoinCode();
        }
        // Lo marca como nuevo
        _context.SchoolClasses.Add(schoolClass);
        // espera a que termine y guarda los cambios
        await _context.SaveChangesAsync();
        return schoolClass;
    }

    public async Task<SchoolClass> UpdateAsync(SchoolClass schoolClass)
    {
        //lo marca como que ya existe y esta modificado
        _context.Entry(schoolClass).State = EntityState.Modified;
        // espera a que termine y guarda los cambios
        await _context.SaveChangesAsync();
        return schoolClass;
    }

    public async Task DeleteAsync(int id)
    {
        //busca que exista primero
        var schoolClass = await _context.SchoolClasses.FindAsync(id);
        if (schoolClass != null)
        {
            // si existe lo marca como eliminado
            _context.SchoolClasses.Remove(schoolClass);
            // y guarda los cambios
            await _context.SaveChangesAsync();
        }
    }

    public async Task<SchoolClass> JoinSchoolClassAsync(string joinCode, int userId)
    {
        // busca en la clase que tenga ese codigo y se trae la lista de estudiantes
        var schoolClass = await _context.SchoolClasses
            .Include(sc => sc.Students)
            .FirstOrDefaultAsync(sc => sc.JoinCode == joinCode);

        if (schoolClass != null)
        {
            // sino encuentra ninguna clase lanza la exception
            throw new KeyNotFoundException("Clase no encontrada con ese código.");
        }
        
        //busca que el usuario exista esto ya que solo recibimos el id no el usuario completo
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            throw new KeyNotFoundException("Usuario no encontrado.");
        }
        
        //busca si el usuario ya esta en la clase 
        if (!schoolClass.Students.Any(u => u.Id == userId))
        {
            // de no ser asi lo marca como agregado
            schoolClass.Students.Add(user);
            
        }
    //y guarda los cambios
        await _context.SaveChangesAsync();
        return schoolClass;
    }

    public async Task<bool> LeaveSchoolClassAsync(int classId, int userId)
    {
        //Busca que la clase con ese Id exista 
        var schoolClass = await _context.SchoolClasses
            .Include(sc => sc.Students)
            .FirstOrDefaultAsync(sc => sc.Id == classId);

        if (schoolClass == null)
        {
            return false;
        }
        
        //busca que el usuario exista esto ya que solo recibimos el id no el usuario completo
        var user = schoolClass.Students.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return false;
        }
        
        //marcamos el user como removido
        schoolClass.Students.Remove(user);
        //guardamos los cambios
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<User>> GetAllStudentsByIdClassAsync(int classId)
    {
        return await _context.SchoolClasses
                //buscal la clase con ese id
            .Where(sc => sc.Id == classId)
                //Trae todos los estudiantes
            .SelectMany(sc => sc.Students)
                //retorna en lista
            .ToListAsync();
    }

    public async Task<IEnumerable<Team>> GetAllTeamsByIdClassAsync(int classId)
    {
        //aca cambia ya que teams tiene un FK que apunta a clases 
        return await _context.Teams
                //Solo traemos los teams con ese Fk de ese Id
            .Where(t => t.SchoolClassId == classId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Activity>> GetAllActivitiesByIdClassAsync(int classId)
    {
        //Lo mismo de arriba
        return await _context.Activities
            .Where(a => a.SchoolClassId == classId)
            .ToListAsync();
    }
}