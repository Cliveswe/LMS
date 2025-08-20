using Domain.Models.Responses;
using LMS.Shared.DTOs.CourseDtos;

namespace Service.Contracts;

public interface ICourseService
{

    void AddCourse(CourseCreateDto courseCreateDto);

    Task<ApiBaseResponse> GetAllAsync();
}