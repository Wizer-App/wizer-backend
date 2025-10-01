using Application.Interfaces;
using Application.SchoolClasses.Queries;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Handlers;

//lo mismo que lo de query y command pero se pasa antes la query o command
public class GetAllSchoolClassByUserIdHandler : IRequestHandler<GetAllSchoolClassByUserIdQuery, IEnumerable<SchoolClass>>
{
    //en estos inyectamos el repository donde definimos los metodos
    private readonly ISchoolClassRepository _repository;
    public GetAllSchoolClassByUserIdHandler(ISchoolClassRepository repository)
    {
        _repository = repository;
    }
    //creamos el handle con lo que va retornar y de parametro la query y el cancelationtoken de MediatR
    public async Task<IEnumerable<SchoolClass>> Handle(GetAllSchoolClassByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        //solamente llamamos al repository y retornamos
        var classes = await _repository.GetAllSchoolClassByUserIdAsync(request.UserId);
        return classes;
    }
}
