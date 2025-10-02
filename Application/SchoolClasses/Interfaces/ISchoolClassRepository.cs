using Domain.Entities;

namespace Application.Interfaces;

public interface ISchoolClassRepository
{
    //Task indica que es asincrono
    // IEnumerable es que no se sabe si es List array o otra cosa
    Task<IEnumerable<SchoolClass>> GetAllSchoolClassByUserIdAsync(int userId); 
    // ? que puede ser nulo 
    Task<SchoolClass?> GetByIdAsync(int id);
    Task<SchoolClass> AddAsync(SchoolClass schoolClass);
    Task<SchoolClass> UpdateAsync(int schoolClassId, SchoolClass schoolClass);
    Task DeleteAsync(int id);
    Task<SchoolClass> JoinSchoolClassAsync(string joinCode, int userId);
    Task<bool> LeaveSchoolClassAsync(int classId, int userId);
    Task<IEnumerable<User>> GetAllStudentsByIdClassAsync(int classId);
    Task<IEnumerable<Team>> GetAllTeamsByIdClassAsync(int classId);
    Task<IEnumerable<Activity>> GetAllActivitiesByIdClassAsync(int classId);
}