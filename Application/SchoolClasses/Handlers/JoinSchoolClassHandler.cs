using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Commands;
using AutoMapper;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class JoinSchoolClassHandler : IRequestHandler<JoinSchoolClassCommand, SchoolClassDto>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;

    public JoinSchoolClassHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<SchoolClassDto> Handle(JoinSchoolClassCommand request, CancellationToken cancellationToken)
    {
        // validar que exista el user
        var schoolClass = await _repository.JoinSchoolClassAsync(request.JoinCode, request.UserId);
        
        if (schoolClass == null)
        {
            throw new KeyNotFoundException($"Clase con ID {request.JoinCode} no encontrada");
        }
        var schoolClassDto = _mapper.Map<SchoolClassDto>(schoolClass);
        return schoolClassDto;
    }
}