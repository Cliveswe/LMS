using Domain.Models.Entities;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Service.Contracts
{
    public interface IModuleActivityService
    {
        Task CreateActivityAsync(CreateModuleActivityDto newModuleActivityDto);
        Task PatchModuleActivityAsync(int id, JsonPatchDocument<PatchModuleActivityDto> patchDoc);
        IEnumerable<ModuleActivity> GetActivitiesByModule(int moduleId);
    }
}