using Application.DTOs;
using Application.Interfaces;
using Application.Users.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.Handlers;

public class AddHandler : IRequestHandler<AddCommand, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public AddHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<UserDto> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(request.UserDto);
        var addedUser = await _repository.AddAsync(userEntity);
        var userDto = _mapper.Map<UserDto>(addedUser);
        return userDto;

    }
}