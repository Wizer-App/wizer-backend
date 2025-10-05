using Application.Interfaces;
using Application.Notifications.Interfaces;
using Application.SchoolClasses.Commands;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class LeaveSchoolClassHandler : IRequestHandler<LeaveSchoolClassCommand, bool>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IRealTimeNotifier _notifier;

    public LeaveSchoolClassHandler(ISchoolClassRepository repository,  IRealTimeNotifier notifier)
    {
        _repository = repository;
        _notifier = notifier;
    }
    
    public async Task<bool> Handle(LeaveSchoolClassCommand request, CancellationToken cancellationToken)
    {
        var isDelete = await _repository.LeaveSchoolClassAsync(request.ClassId, request.UserId);
        
        await _notifier.NotifyClassAsync(request.ClassId, "UserLeft", new { userId = request.UserId });
    
        Console.WriteLine($"📢 UserLeft enviado: ClassId={request.ClassId}, UserId={request.UserId}");
    
        return isDelete;
    }
}