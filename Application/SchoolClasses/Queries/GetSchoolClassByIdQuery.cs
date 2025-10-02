using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;

public class GetSchoolClassByIdQuery : IRequest<SchoolClassDto>
{  
    public int Id { get;}
    
    public GetSchoolClassByIdQuery(int id)
    {
        Id = id;
    }
}