namespace Domain.Models.Entities;
public class Module
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StarDate { get; set; } = DateTime.MinValue;
    public DateTime EndDate { get; set; } = DateTime.MaxValue;
    public ICollection<Course> Courses { get; set; } = []; // nav prop
    public ICollection<ModuleActivity> Activities { get; set; } = []; // nav prop
}
