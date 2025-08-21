//Ignore Spelling: api dto json
using LMS.Shared.DTOs.CourseDtos;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers.CourseControllers;

[Route("api/course")]
[ApiController]
[Produces("application/json")] // Ensures all responses are documented as JSON
public class CoursesController(IServiceManager serviceManager) : Controller
{

    [HttpPost]
    [Consumes("application/json")] // Correct MIME type for POSTing a DTO
    public IActionResult CreateCourse(CourseCreateDto courseCreateDto)
    {
        var t = serviceManager.CourseService.CourseExistsAsync(courseCreateDto.CourseName, courseCreateDto.CourseStartDate);

        Task<Domain.Models.Responses.ApiBaseResponse> res = serviceManager.CourseService.AddCourseAsync(courseCreateDto);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
    {
        var result = await serviceManager.CourseService.GetAllAsync();
        return Ok(result);
    }
}
