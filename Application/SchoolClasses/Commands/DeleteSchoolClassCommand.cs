using MediatR;

namespace Application.SchoolClasses.Commands;

public class DeleteSchoolClassCommand : IRequest<Unit>
{
    public int Id { get; }

    public DeleteSchoolClassCommand(int id)
    {
        Id = id;
    }
}