using LMS.Shared.DTOs.ModuleDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Presentation.Controllers.ModuleControllers;

[Route("api/courses/{courseId}/modules")]
[ApiController]

public class ModulesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAllModules(int courseId)
    {
        var modules = await serviceManager.ModuleService.GetAllModulesAsync(courseId);
        return Ok(modules);
    }

    [HttpGet("{moduleId:int}")]
    [Authorize]
    public async Task<ActionResult<ModuleDto>> GetModuleById(int courseId, int moduleId)
    {
        var module = await serviceManager.ModuleService.GetModuleByIdAsync(courseId, moduleId);
        return Ok(module);
    }
}
