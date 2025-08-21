using Domain.Models.Responses;
using LMS.Shared.DTOs.CourseDtos;

namespace Service.Contracts;

public interface ICourseService
{

    Task<ApiBaseResponse> AddCourseAsync(CourseCreateDto courseCreateDto);

    Task<ApiBaseResponse> GetAllAsync();

    Task<ApiBaseResponse> CourseExistsAsync(string name, DateTime startDate);
}