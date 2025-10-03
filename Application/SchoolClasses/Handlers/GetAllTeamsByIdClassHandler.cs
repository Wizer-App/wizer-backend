using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Queries;
using AutoMapper;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class GetAllTeamsByIdClassHandler : IRequestHandler<GetAllTeamsByIdClassQuery, IEnumerable<TeamDto>>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;

    public GetAllTeamsByIdClassHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamsByIdClassQuery request, CancellationToken cancellationToken)
    {
        var teams = await _repository.GetAllTeamsByIdClassAsync(request.ClassId);
        var teamDtos = _mapper.Map<IEnumerable<TeamDto>>(teams);
        return teamDtos;
    }
}