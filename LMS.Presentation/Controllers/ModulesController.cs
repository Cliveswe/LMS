using LMS.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Presentation.Controllers;

[Route("api/modules")]
[ApiController]

public class ModulesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ModulesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
    }

    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAllModules(int courseId)
    {
        var modules = await _serviceManager.ModuleService.GetAllModulesAsync(courseId);
        return Ok(modules);
    }

    [HttpGet("{moduleId:int}")]
    //[Authorize]
    public async Task<ActionResult<ModuleDto>> GetModuleById(int moduleId)
    {
        var module = await _serviceManager.ModuleService.GetModuleByIdAsync(moduleId);
        return Ok(module);
    }
}
