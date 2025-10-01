using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class AddCommand : IRequest<User>
{
    public User User { get; }

    public AddCommand(User user)
    {
        User = user;
    }
}