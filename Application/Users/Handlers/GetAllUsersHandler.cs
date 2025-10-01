using Application.Interfaces;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _repository;
    public GetAllUsersHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllUsersAsync();
        return users;
    }
}