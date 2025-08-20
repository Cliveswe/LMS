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
    public async Task<ApiBaseResponse> AddCourseAsync(CourseCreateDto courseCreateDto)
    {
        if (courseCreateDto is null)
            throw new ArgumentNullException(nameof(courseCreateDto));

        // Map DTO -> Entity
        Course course = mapper.Map<Course>(courseCreateDto);

        // Add using repository
        unitOfWork.Courses.Add(course);
        int changes = await unitOfWork.CompleteAsync();

        if (changes == 0)
        {
            return new ApiFailedSaveResponse("Failed to save the new course.");
        }
        CourseDto courseDto = mapper.Map<CourseDto>(courseCreateDto);

        return new ApiOkResponse<CourseDto>(courseDto, "Course successfully created.");
    }

    public async Task<ApiBaseResponse> GetAllAsync()
    {
        IEnumerable<Course> course = await unitOfWork.Courses.GetAllAsync();

        IEnumerable<CourseDto> courseDto = mapper.Map<IEnumerable<CourseDto>>(course);

        return new ApiOkResponse<IEnumerable<CourseDto>>(courseDto);
    }

}
