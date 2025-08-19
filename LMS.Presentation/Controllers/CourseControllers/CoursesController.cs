//Ignore Spelling: api dto
using LMS.Shared.DTOs.CourseDtos;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers.CourseControllers;

[Route("api/course")]
[ApiController]
public class CoursesController(IServiceManager serviceManager) : Controller
{

    [HttpPost]
    public IActionResult CreateCourse(CourseCreateDto courseCreateDto)
    {

        serviceManager.CourseService.AddCourse(courseCreateDto);

        return Ok();
    }
}
