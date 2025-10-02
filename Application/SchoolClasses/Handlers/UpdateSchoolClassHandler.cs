using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class UpdateSchoolClassHandler : IRequestHandler<UpdateSchoolClassCommand, SchoolClassDto>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;

    public UpdateSchoolClassHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<SchoolClassDto> Handle(UpdateSchoolClassCommand request, CancellationToken cancellationToken)
    {
        var schoolClass = await _repository.GetByIdAsync(request.SchoolClassId);

        if (schoolClass == null)
        {
            throw new Exception("Clase no encontrada");
        }
        
        schoolClass.Name = request.UpdateSchoolClassDto.Name;
        schoolClass.Description = request.UpdateSchoolClassDto.Description;
        var updated = await _repository.UpdateAsync(request.SchoolClassId,schoolClass);
        var schoolClassDto = _mapper.Map<SchoolClassDto>(updated);
        return schoolClassDto;
    }
}