using Application.DTOs;
using Domain.Entities;
using AutoMapper;

namespace Application.Teams.Mapping;

public class ActivityProfile : Profile
{
    public ActivityProfile()
    {   
        CreateMap<Activity, ActivityDto>();
        CreateMap<ActivityDto, Activity>();
    }
}