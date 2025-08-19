using AutoMapper;
using Domain.Models.Entities;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.CourseDtos;

namespace LMS.Infrastructure.Data;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UserRegistrationDto, ApplicationUser>();

        // Course mapping
        CreateMap<CourseCreateDto, Course>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CourseName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CourseDescription))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.CourseStartDate));

        //TODO: Add a mapping profile for get all courses.
    }
}
