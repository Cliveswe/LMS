using Domain.Models.Entities;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers
{
    [Route("/api/courses/modules/{moduleId:int}/module-activity")]
    [ApiController]
    public class ModuleActivityController(IServiceManager sm) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateActivityAsync(int moduleId, CreateModuleActivityDto dto)
        {
            await sm.ModuleActivityService.CreateActivityAsync(moduleId, dto);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [Authorize]
        public async Task PatchActivityAsync(int id, JsonPatchDocument<PatchModuleActivityDto> patchDoc)
        {
            await sm.ModuleActivityService.PatchModuleActivityAsync(id, patchDoc);
        }
        
        [HttpGet]
        [Authorize]
        public IEnumerable<ModuleActivity> GetActivitiesByModule(int moduleId)
        {
            return sm.ModuleActivityService.GetActivitiesByModule(moduleId);
        }
    }
}
