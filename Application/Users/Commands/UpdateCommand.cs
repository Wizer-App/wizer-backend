using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class UpdateCommand : IRequest<User>
{
    public User User { get; }

    public UpdateCommand(User user)
    {
        User = user;
    }
}