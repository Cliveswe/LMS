using Domain.Models.Responses;
using LMS.Shared.DTOs.CourseDtos;

namespace Service.Contracts;

public interface ICourseService
{

    Task<ApiBaseResponse> AddCourseAsync(CourseCreateDto courseCreateDto);

    Task<ApiBaseResponse> GetAllAsync();

    Task<ApiBaseResponse> GetCourseByIdAsync(int id);

    Task<ApiBaseResponse> GetCourseByNameAndStartDateAsync(string name, DateTime startDate);

    Task<ApiBaseResponse> CourseExistsAsync(string name, DateTime startDate);
}