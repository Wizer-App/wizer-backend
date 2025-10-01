using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Queries;
//: IRequest y metemos ahi lo que retorna
public class GetAllSchoolClassByUserIdQuery :IRequest<IEnumerable<SchoolClassDto>>
{
    //inicializamos los parametros y creamos el constructor
    public int UserId { get; }
    public GetAllSchoolClassByUserIdQuery(int userId)
    {
        UserId = userId;
    }
}