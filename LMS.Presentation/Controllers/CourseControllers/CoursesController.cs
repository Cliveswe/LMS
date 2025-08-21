//Ignore Spelling: api dto json
using Domain.Models.Responses;
using LMS.Shared.DTOs.CourseDtos;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers.CourseControllers;

[Route("api/course")]
[ApiController]
[Produces("application/json")] // Ensures all responses are documented as JSON
public class CoursesController(IServiceManager serviceManager) : ApiControllerBase
{

    [HttpPost]
    [Consumes("application/json")] // Correct MIME type for POSTing a DTO
    public async Task<ActionResult> CreateCourse(CourseCreateDto courseCreateDto)
    {
        //Check if the course already exists.
        ApiBaseResponse courseEntityExists = await serviceManager.CourseService.CourseExistsAsync(courseCreateDto.CourseName, courseCreateDto.CourseStartDate);
        if (courseEntityExists.Success)
        {
            return ProcessError(new ApiAlreadyExistsResponse($"A course with course name \"{courseCreateDto.CourseName}\" with start date: {courseCreateDto.CourseStartDate}, already exists."));
        }

        ApiBaseResponse courseServiceResponse = await serviceManager.CourseService.AddCourseAsync(courseCreateDto);
        if (!courseServiceResponse.Success)
        {
            return ProcessError(new ApiFailedSaveResponse("Could not save the newly created Course."));
        }

        return HandleResponse(courseServiceResponse);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
    {
        ApiBaseResponse courseGetAllServiceResponse = await serviceManager.CourseService.GetAllAsync();

        return HandleResponse<IEnumerable<CourseDto>>(courseGetAllServiceResponse);
    }
}
