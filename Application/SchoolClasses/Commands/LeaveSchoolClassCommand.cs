using MediatR;

namespace Application.SchoolClasses.Commands;

public class LeaveSchoolClassCommand : IRequest<bool>
{
    public int ClassId { get; }
    public int UserId { get; }
    
    public LeaveSchoolClassCommand(int classId, int userId)
    {
        ClassId = classId;
        UserId = userId;
    }
}