//Ignore Spelling: api dto
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

        serviceManager.CourseService.AddCourse(courseCreateDto);

        return Ok();
    }


    //TODO: Create endpoint to get all courses.
}
