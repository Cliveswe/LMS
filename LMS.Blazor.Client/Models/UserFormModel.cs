using System.ComponentModel.DataAnnotations;

namespace LMS.Blazor.Client.Models;
public class UserFormModel
{
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public string? Role { get; set; }

    public List<int> SelectedCourseIds { get; set; } = [];
}
