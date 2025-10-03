using Application.Interfaces;
using Application.SchoolClasses.Commands;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class LeaveSchoolClassHandler : IRequestHandler<LeaveSchoolClassCommand, bool>
{
    private readonly ISchoolClassRepository _repository;

    public LeaveSchoolClassHandler(ISchoolClassRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(LeaveSchoolClassCommand request, CancellationToken cancellationToken)
    {
        var isDelete = await _repository.LeaveSchoolClassAsync(request.ClassId, request.UserId);
        return isDelete;
    }
}