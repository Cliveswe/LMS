//Ignore Spelling: dto
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using Domain.Models.Responses;
using LMS.Shared.DTOs.CourseDtos;
using Service.Contracts;

namespace LMS.Services;
public class CourseService(IMapper mapper, IUnitOfWork unitOfWork) : ICourseService
{
    public void AddCourse(CourseCreateDto courseCreateDto)
    {
        if (courseCreateDto is null)
            throw new ArgumentNullException(nameof(courseCreateDto));

        // Map DTO -> Entity
        var course = mapper.Map<Course>(courseCreateDto);

        // Add using repository
        unitOfWork.Courses.Add(course);

        // Save changes
        unitOfWork.CompleteAsync().GetAwaiter().GetResult(); // synchronous call for now
    }

    public async Task<ApiBaseResponse> GetAllAsync()
    {
        IEnumerable<Course> course = await unitOfWork.Courses.GetAllAsync();

        IEnumerable<CourseDto> courseDto = mapper.Map<IEnumerable<CourseDto>>(course);

        return new ApiOkResponse<IEnumerable<CourseDto>>(courseDto);
    }

}
