using Application.Interfaces;
using Application.Users.Queries;
using Application.DTOs;
using MediatR;
using AutoMapper;

namespace Application.Users.Handlers;

public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public GetAllStudentsHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _repository.GetAllStudentsAsyc();
        var userDto = _mapper.Map<IEnumerable<UserDto>>(students);
        return userDto;
    }
}