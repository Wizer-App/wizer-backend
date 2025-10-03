using Application.Interfaces;
using Application.Users.Queries;
using Application.DTOs;
using MediatR;
using AutoMapper;

namespace Application.Users.Handlers;

public class GetAllTeachersHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepository _reppository;
    private readonly IMapper _mapper;
    public GetAllTeachersHandler(IUserRepository repository, IMapper mapper)
    {
        _reppository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _reppository.GetAllTeachersAsync();
        var userDto = _mapper.Map<IEnumerable<UserDto>>(teachers);
        return userDto;
    }
}