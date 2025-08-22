using Domain.Models.Entities;
using Domain.Models.Responses;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers
{
    [Route("/api/courses/{courseId:int}/modules/{moduleId:int}/module-activity")]
    [ApiController]
    [Authorize]
    public class ModuleActivityController(IServiceManager sm) : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateActivityAsync(int moduleId, CreateModuleActivityDto dto)
        {
            ApiBaseResponse moduleActivityResponse = await sm.ModuleActivityService.CreateActivityAsync(moduleId, dto);
            return HandleResponse(moduleActivityResponse);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchActivityAsync(int id, JsonPatchDocument<PatchModuleActivityDto> patchDoc)
        {
            ApiBaseResponse moduleActivityResponse = await sm.ModuleActivityService.PatchModuleActivityAsync(id, patchDoc);
            return HandleResponse(moduleActivityResponse);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetActivitiesByModule(int moduleId)
        {
            ApiBaseResponse moduleActivityResponse = await sm.ModuleActivityService.GetActivitiesByModule(moduleId);
            return HandleResponse(moduleActivityResponse);
        }
    }
}
