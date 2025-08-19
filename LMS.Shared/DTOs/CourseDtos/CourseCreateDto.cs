//Ignore Spelling: dto
namespace LMS.Shared.DTOs.CourseDtos;
public record CourseCreateDto
{
    public required string CourseName { get; set; }
    public required string CourseDescription { get; set; }
    public required DateTime CourseStartDate { get; set; }

}
