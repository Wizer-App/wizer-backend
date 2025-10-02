using Application.Interfaces;
using Application.SchoolClasses.Commands;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class DeleteSchoolClassHandler : IRequestHandler<DeleteSchoolClassCommand, Unit>
{
    private readonly ISchoolClassRepository _repository;

    public DeleteSchoolClassHandler(ISchoolClassRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Unit> Handle(DeleteSchoolClassCommand request, CancellationToken cancellationToken)
    {
        var schoolClass = await _repository.GetByIdAsync(request.Id);

        if (schoolClass == null)
        {
            throw new KeyNotFoundException($"Clase con ID {request.Id} no encontrada");
        }

        await _repository.DeleteAsync(request.Id);
        
        return Unit.Value;
    }
}