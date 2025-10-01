using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;

public class GetByIdQuery : IRequest<SchoolClass>
{  
    public int Id { get;}
    
    public GetByIdQuery(int id)
    {
        Id = id;
    }
}