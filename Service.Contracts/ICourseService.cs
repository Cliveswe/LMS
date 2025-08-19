using LMS.Shared.DTOs.CourseDtos;

namespace LMS.Services;

public interface ICourseService
{

    void AddCourse(CourseCreateDto courseCreateDto);
}