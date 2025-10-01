using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;

public class GetSchoolClassByIdQuery : IRequest<SchoolClass>
{  
    public int Id { get;}
    
    public GetSchoolClassByIdQuery(int id)
    {
        Id = id;
    }
}