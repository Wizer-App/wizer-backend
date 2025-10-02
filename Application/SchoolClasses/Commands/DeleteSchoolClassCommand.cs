using MediatR;

namespace Application.SchoolClasses.Commands;

public class DeleteCommand : IRequest<Unit>
{
    public int Id { get; }

    public DeleteCommand(int id)
    {
        Id = id;
    }
}