using Application.DTOs;
using Application.Interfaces;
using Application.Users.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

public class UpdateHandler : IRequestHandler<UpdateCommand, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UpdateHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<UserDto> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var user = await (_repository.GetByIdAsync(request.UserId));
        if (user == null)
        {
            throw new Exception("Usuario no encontrado");
        }
        user.Username = request.UpdateUser.Username;
        user.Name = request.UpdateUser.Name;
        user.LastName = request.UpdateUser.LastName;
        var updated = await _repository.UpdateAsync(request.UserId, user);
        var userDto = _mapper.Map<UserDto>(updated);
        return userDto;

    }
}