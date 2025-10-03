using Application.Interfaces;
using Application.Users.Queries;
using Application.DTOs;
using MediatR;
using AutoMapper;

namespace Application.Users.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public GetAllUsersHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllUsersAsync();
        var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
        return userDto;
    }
}