using Domain.Models.Entities;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers
{
    [Route("/api/module-activity")]
    [ApiController]
    public class ModuleActivityController(IServiceManager sm) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateActivityAsync(CreateModuleActivityDto dto)
        {
            await sm.ModuleActivityService.CreateActivityAsync(dto);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task PatchActivityAsync(int id, JsonPatchDocument<PatchModuleActivityDto> patchDoc)
        {
            await sm.ModuleActivityService.PatchModuleActivityAsync(id, patchDoc);
        }

    }
}
