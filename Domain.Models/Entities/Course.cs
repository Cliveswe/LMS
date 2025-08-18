namespace Domain.Models.Entities;
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public ICollection<ApplicationUser> Users { get; set; } = []; // nav prop
    public ICollection<Module> Modules { get; set; } = []; // nav prop
}
