using MediatR;

namespace Application.Users.Commands;

public class DeleteCommand : IRequest<Unit>
{
    public int Id { get; }

    public DeleteCommand(int id)
    {
        Id = id;
    }
}