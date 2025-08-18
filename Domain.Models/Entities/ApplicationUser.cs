using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
    public List<Course> Courses { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

}
