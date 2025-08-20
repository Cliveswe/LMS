using LMS.Shared.DTOs.CourseDtos;

namespace Service.Contracts;

public interface ICourseService
{

    void AddCourse(CourseCreateDto courseCreateDto);

    Task<IEnumerable<CourseDto>> GetAllAsync();
}