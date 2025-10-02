using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Handlers;

//lo mismo que lo de query y command pero se pasa antes la query o command
public class GetAllSchoolClassByUserIdHandler : IRequestHandler<GetAllSchoolClassByUserIdQuery, IEnumerable<SchoolClassDto>>
{
    //en estos inyectamos el repository donde definimos los metodos
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;
    public GetAllSchoolClassByUserIdHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    //creamos el handle con lo que va retornar y de parametro la query y el cancelationtoken de MediatR
    public async Task<IEnumerable<SchoolClassDto>> Handle(GetAllSchoolClassByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        //solamente llamamos al repository y retornamos
        var schoolClass = await _repository.GetAllSchoolClassByUserIdAsync(request.UserId);
        var schoolClassDto = _mapper.Map<IEnumerable<SchoolClassDto>>(schoolClass);
        return schoolClassDto;
    }
}
