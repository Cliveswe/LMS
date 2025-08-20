using LMS.Blazor.Client.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UserManager<ApplicationUser> userManager) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UserFormModel>> GetUser(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        UserFormModel userModel = new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role
        };

        return Ok(userModel);
    }
}
