using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Queries;
using AutoMapper;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class  GetSchoolClassByIdHandler : IRequestHandler<GetSchoolClassByIdQuery, SchoolClassDto>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;

    public GetSchoolClassByIdHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolClassDto> Handle(GetSchoolClassByIdQuery request, CancellationToken cancellationToken)
    {
        var schoolClass = await _repository.GetByIdAsync(request.Id);
        var schoolClassDto = _mapper.Map<SchoolClassDto>(schoolClass);
        return schoolClassDto;
    }
}