using Application.Interfaces;
using Application.Users.Queries;
using Application.DTOs;
using MediatR;
using AutoMapper;

namespace Application.Users.Handlers;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public GetByIdHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<UserDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.UserId);
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}