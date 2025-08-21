//Ignore Spelling: api lms
using Domain.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        [NonAction]
        public ActionResult ProcessError(ApiBaseResponse baseResponse)
        {
            ProblemDetails problem = baseResponse switch
            {
                // Kräver Microsoft.AspNetCore.Mvc.NewtonsoftJson
                ApiNotFoundResponse notFound => CreateProblemResult(
                 "Not found", notFound.Message!, notFound.StatusCode),

                ApiAlreadyExistsResponse alreadyExists => CreateProblemResult(
                    "Conflict", alreadyExists.Message!, alreadyExists.StatusCode),

                // A generic response as an alternative to a "Throw"
                _ => CreateProblemResult(
                    "Error", baseResponse.Message ?? "An error occurred.", baseResponse.StatusCode)
            };

            return new ObjectResult(problem)
            {
                StatusCode = problem.Status
            };
        }
        private ProblemDetails CreateProblemResult(string title, string detail, int statusCode)
        {
            // Built-in properties of the Microsoft.AspNetCore.Mvc.ProblemDetails class.
            var problemDetails = new ProblemDetails
            {
                Title = title,
                Detail = detail,
                Status = statusCode,
                Instance = HttpContext.Request.Path,
            };

            return problemDetails;
        }

        //Use this when you expect a typed result back from the service (like a DTO or collection of DTOs).
        protected ActionResult<T> HandleResponse<T>(ApiBaseResponse response) =>
            response.Success
            ? Ok(response.GetOkResult<T>()) // Return the typed success result (e.g., a DTO or collection)
            : ProcessError(response);// If delete was not successful

        //Use this when you're not expecting a typed DTO, but just want to return a general Ok(...) or
        //handle errors. This is common in PUT, DELETE, etc., where success might just mean an operation completed.
        protected ActionResult HandleResponse(ApiBaseResponse response) =>
            response.Success
            ? Ok(response) // Return the deleted object wrapped in ApiOkResponse
            : ProcessError(response);// If delete was not successful
    }
}