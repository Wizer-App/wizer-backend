using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class AddSchoolClassHandler : IRequestHandler<AddSchoolClassCommand, SchoolClassDto>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;
    public AddSchoolClassHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<SchoolClassDto> Handle(AddSchoolClassCommand request, CancellationToken cancellationToken)
    {
        var schoolClassEntity = _mapper.Map<SchoolClass>(request.SchoolClassDto);
        var addedSchoolClass = await _repository.AddAsync(schoolClassEntity);
        var schoolClassDto = _mapper.Map<SchoolClassDto>(addedSchoolClass);
        return schoolClassDto;
    }
}