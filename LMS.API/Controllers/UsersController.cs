using LMS.Shared.DTOs.UserDtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetAsync(string id)
    {
        var user = await serviceManager.UserService.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> PostAsync(UserDto userDto)
    {
        var user = await serviceManager.UserService.PostAsync(userDto);
        return CreatedAtAction("GetUser", new { User = user }, user);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<UserDto>> PatchAsync(
        string id,
        [FromBody] JsonPatchDocument<UserDto> patchDoc)
    {
        if (patchDoc is null) { return BadRequest(); }
        var user = await serviceManager.UserService.PatchAsync(id, patchDoc);
        return Ok(user);
    }
}
