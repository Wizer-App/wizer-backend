using Application.DTOs;
using Domain.Entities;
using AutoMapper;

namespace Application.SchoolClasses.Mapping;

public class SchoolClassProfile : Profile
{
    public SchoolClassProfile()
    {   
        CreateMap<User, UserDto>();

        // Mapeo de SchoolClass -> SchoolClassDto
        CreateMap<SchoolClass, SchoolClassDto>()
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));

        // También tu mapeo inverso si lo necesitas
        CreateMap<SchoolClassDto, SchoolClass>()
            .ForMember(dest => dest.Teacher, opt => opt.Ignore());
    }
}