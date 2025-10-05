using Application.DTOs;
using Application.Interfaces;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Users.Handlers;

public class CreateInfoUserHandler : IRequestHandler<CreateInfoUserCommand, InfoUserDto>
{
    private readonly IInfoUserRepository _repository;
    
    public CreateInfoUserHandler(IInfoUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<InfoUserDto> Handle(CreateInfoUserCommand request, CancellationToken cancellationToken)
    {
        var infoUserEntity = new InfoUser
        {
            Career = request.InfoUserDto.Career!,
            ProfessionalTitle = request.InfoUserDto.ProfessionalTitle,
            Semester = request.InfoUserDto.Semester,
            Tuition = request.InfoUserDto.Tuition
        };

        var addedInfoUser = await _repository.AddInfoUserAsync(infoUserEntity);
    
        var infoUserDto = new InfoUserDto
        {
            Id = addedInfoUser.Id,
            Career = addedInfoUser.Career,
            ProfessionalTitle = addedInfoUser.ProfessionalTitle,
            Semester = addedInfoUser.Semester,
            Tuition = addedInfoUser.Tuition
        };
        
        return infoUserDto;
    }
}