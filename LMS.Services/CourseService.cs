//Ignore Spelling: dto
using AutoMapper;
using Domain.Contracts.Repositories;
using LMS.Shared.DTOs.CourseDtos;
using Service.Contracts;

namespace LMS.Services;
public class CourseService(IMapper mapper, IUnitOfWork unitOfWork) : ICourseService
{
    public void AddCourse(CourseCreateDto courseCreateDto)
    {
        throw new NotImplementedException();
    }
}
