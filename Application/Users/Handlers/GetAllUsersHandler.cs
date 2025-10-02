using Application.Interfaces;
using Application.Users.Queries;
using Domain.Entities;
using Application.DTOs;
using MediatR;

namespace Application.Users.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepository _repository;
    public GetAllUsersHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllUsersAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username,
            Name = u.Name,
            LastName = u.LastName,
            Photo = u.Photo,
            CreatedAt = u.Created,
            TypeUser = u.TypeUser
        }).ToList();
    }
}