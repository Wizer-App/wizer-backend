using Application.Interfaces;
using Application.Users.Commands;
using MediatR;

namespace Application.Users.Handlers;

public class DeleteHandler : IRequestHandler<DeleteCommand, Unit>
{

    private readonly IUserRepository _repository;
    public DeleteHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);
        if (user == null)
        {
            throw new KeyNotFoundException($"User con ID {request.Id} no encontrado");
        }
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }

}