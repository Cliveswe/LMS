using Domain.Models.Entities;
using Domain.Models.Responses;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Service.Contracts
{
    public interface IModuleActivityService
    {
        Task<ApiBaseResponse> CreateActivityAsync(int moduleId, CreateModuleActivityDto newModuleActivityDto);
        Task<ApiBaseResponse> PatchModuleActivityAsync(int id, JsonPatchDocument<PatchModuleActivityDto> patchDoc);
        Task<ApiBaseResponse> GetActivitiesByModule(int moduleId);
    }
}