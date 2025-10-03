using Application.Interfaces;
using Application.Users.Queries;
using Application.DTOs;
using MediatR;
using AutoMapper;

namespace Application.Users.Handlers;

public class GetByUsernameHandler : IRequestHandler<GetByUsernameQuery, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public GetByUsernameHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<UserDto> Handle(GetByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByUsernameAsync(request.Username);
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}