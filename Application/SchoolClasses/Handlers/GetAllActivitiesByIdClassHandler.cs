using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Queries;
using AutoMapper;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class GetAllActivitiesByIdClassHandler : IRequestHandler<GetAllActivitiesByIdClassQuery, IEnumerable<ActivityDto>>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;

    public GetAllActivitiesByIdClassHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ActivityDto>> Handle(GetAllActivitiesByIdClassQuery request, CancellationToken cancellationToken)
    {
        var activities = await _repository.GetAllActivitiesByIdClassAsync(request.ClassId);
        var activitiesDto = _mapper.Map<IEnumerable<ActivityDto>>(activities);
        return activitiesDto;
    }
}