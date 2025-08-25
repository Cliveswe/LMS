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
        ApiBaseResponse existsResponse = await serviceManager
            .CourseService
            .CourseExistsAsync(courseCreateDto.CourseName, courseCreateDto.CourseStartDate);

        if (existsResponse is ApiAlreadyExistsResponse)
        {
            return ProcessError(existsResponse);
        }

        //Add the new course.
        ApiBaseResponse courseServiceResponse = await serviceManager
            .CourseService
            .AddCourseAsync(courseCreateDto);

        if (!courseServiceResponse.Success)
        {
            return ProcessError(new ApiFailedSaveResponse("Could not save the newly created Course."));
        }


        // If the response includes a CreatedId, generate Location header dynamically
        if (courseServiceResponse is ApiCreatedResponse created && created.CreatedId.HasValue)
        {
            Response.Headers.Add("Location", $"/api/courses/{created.CreatedId.Value}");
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
    [ProducesResponseType(typeof(ApiOkResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiConcreteNotFoundResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiFailedSaveResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteCourseById(int id)
    {
        ApiBaseResponse response = await serviceManager.CourseService.RemoveCourseAsync(id);

        if (response is null)
        {
            return ProcessError(new ApiFailedSaveResponse("An error occurred while attempting to delete the course."));
        }

        if (!response.Success)
        {
            return ProcessError(response);
        }

        return HandleResponse(response);
    }
}
