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

        // Map DTO -> Entity
        Course courseEntity = mapper.Map<Course>(courseCreateDto);

        // Add using repository
        unitOfWork.CourseRepository.Add(courseEntity);
        int changes = await unitOfWork.CompleteAsync();

        if (changes == 0)
        {
            return new ApiFailedSaveResponse("Failed to save the new course.");
        }
        CourseDto courseDto = mapper.Map<CourseDto>(courseEntity);

        //return new ApiOkResponse<CourseDto>(courseDto, "Course successfully created.");
        return new ApiCreatedResponse("Course successfully created.");
    }

    public async Task<ApiBaseResponse> GetAllAsync()
    {
        IEnumerable<Course> course = await unitOfWork.CourseRepository.GetAllAsync();

        IEnumerable<CourseDto> courseDto = mapper.Map<IEnumerable<CourseDto>>(course);

        return new ApiOkResponse<IEnumerable<CourseDto>>(courseDto);
    }

    public async Task<ApiBaseResponse> CourseExistsAsync(string name, DateTime startDate)
    {
        // Checks existence of a Course by title and start date.

        bool entityExists = await unitOfWork.CourseRepository.CourseExistsByNameAndStartDateAsync(name, startDate);

        return entityExists
            ? new ApiOkResponse<bool>(entityExists)
            : new ApiConcreteNotFoundResponse($"Course {name} with start date {startDate} does not exists.");
    }
}
