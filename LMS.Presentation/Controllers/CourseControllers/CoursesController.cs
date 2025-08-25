//Ignore Spelling: api dto json
using Domain.Models.Responses;
using LMS.Shared.DTOs.CourseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace LMS.Presentation.Controllers.CourseControllers;

[Route("api/courses")]
[ApiController]
[Produces("application/json")] // Ensures all responses are documented as JSON
public class CoursesController(IServiceManager serviceManager) : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ApiCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiAlreadyExistsResponse), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ApiFailedSaveResponse), StatusCodes.Status500InternalServerError)]
    [Consumes("application/json")] // Correct MIME type for POSTing a DTO
    public async Task<ActionResult> CreateCourse(CourseCreateDto courseCreateDto)
    {
        //Check if the course already exists.
        ApiBaseResponse existsResponse = await serviceManager.CourseService.CourseExistsAsync(courseCreateDto.CourseName, courseCreateDto.CourseStartDate);
        if (existsResponse is ApiAlreadyExistsResponse)
        {
            return ProcessError(existsResponse);
        }

        ApiBaseResponse courseServiceResponse = await serviceManager.CourseService.AddCourseAsync(courseCreateDto);
        if (!courseServiceResponse.Success)
        {
            return ProcessError(new ApiFailedSaveResponse("Could not save the newly created Course."));
        }

        //Passed the status codes to this method.
        return HandleResponse(courseServiceResponse);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CourseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiBaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiBaseResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
    {
        ApiBaseResponse courseGetAllServiceResponse = await serviceManager.CourseService.GetAllAsync();

        //If no courses are found, return a 404 Not Found.
        if (!courseGetAllServiceResponse.Success)
        {
            return ProcessError(courseGetAllServiceResponse);
        }

        //Return the results with 200 Ok.
        return HandleResponse<IEnumerable<CourseDto>>(courseGetAllServiceResponse);
    }

    [HttpGet("{id:int}", Name = "GetCourseById")]
    [ProducesResponseType(typeof(ApiBaseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiBaseResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CourseDto>> GetCourseById(int id)
    {

        ApiBaseResponse courseGetByIdServiceResponse = await serviceManager.CourseService.GetCourseByIdAsync(id);

        if (!courseGetByIdServiceResponse.Success)
        {
            return ProcessError(courseGetByIdServiceResponse);
        }

        return HandleResponse<CourseDto>(courseGetByIdServiceResponse);
    }

    [HttpGet("{name}/{startDate:datetime}", Name = "GetCourseByNameAndDateAsync")]
    public async Task<ActionResult<CourseDto>> GetCourseByNameAndDateAsync(string name, DateTime startDate)
    {
        ApiBaseResponse response = await serviceManager.CourseService.GetCourseByNameAndStartDateAsync(name, startDate);

        if (!response.Success)
        {
            return ProcessError(response);
        }

        return HandleResponse<CourseDto>(response);
    }

    [HttpDelete("{id:int}", Name = "DeleteCourseById")]
    public async Task<ActionResult> DeleteCourseById(int id)
    {

        return NoContent();
    }
}
