using AutoMapper;
using Domain.Models.Entities;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.ModuleActivityDtos;

namespace LMS.Infrastructure.Data;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UserRegistrationDto, ApplicationUser>();
        CreateMap<ModuleActivity, CreateModuleActivityDto>().ReverseMap();
        CreateMap<PatchModuleActivityDto, ModuleActivity>().ReverseMap();
    }
}
