//Ignore Spelling: api
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers.CourseControllers;

[Route("api/course")]
[ApiController]
public class CoursesController(IServiceManager serviceManager) : Controller
{

    [HttpPost]
    public IActionResult CreateCourse(string nameOfCourse)
    {


        return Ok();
    }
}
