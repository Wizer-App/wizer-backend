using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.SchoolClasses.Commands;

public class JoinSchoolClassCommand : IRequest<SchoolClassDto>
{
    public string JoinCode { get; set; }
    public int UserId { get; set; }

    public JoinSchoolClassCommand(string joinCode, int userId)
    {
        JoinCode = joinCode;
        UserId = userId;
    }
}