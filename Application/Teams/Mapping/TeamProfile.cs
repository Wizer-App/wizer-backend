using Application.DTOs;
using Domain.Entities;
using AutoMapper;

namespace Application.Teams.Mapping;

public class TeamProfile : Profile
{
    public TeamProfile()
    {   
        CreateMap<Team, TeamDto>();
        CreateMap<TeamDto, Team>();
    }
}