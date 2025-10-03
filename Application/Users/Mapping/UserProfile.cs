using Application.DTOs;
using Domain.Entities;
using AutoMapper;

namespace Application.Users.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // Mapeo User -> UserDto (sin relaciones)
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Created))
            .ForMember(dest => dest.InfoUserId, opt => opt.MapFrom(src => src.InfoUser!.Id));

        // Mapeo UserDto -> User (para crear/actualizar)
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.InfoUser, opt => opt.Ignore())
            .ForMember(dest => dest.Teams, opt => opt.Ignore())
            .ForMember(dest => dest.SchoolClasses, opt => opt.Ignore())
            .ForMember(dest => dest.Activities, opt => opt.Ignore());
    }
}