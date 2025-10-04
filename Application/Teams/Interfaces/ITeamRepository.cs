using Domain.Entities;

namespace Application.Teams.Interfaces;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllTeamsByUserIdAsync(int userId); 
    
    
}