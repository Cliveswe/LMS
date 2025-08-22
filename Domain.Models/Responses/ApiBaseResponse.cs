//Ignore Spelling: api
using Microsoft.AspNetCore.Http;  // for StatusCodes
namespace Domain.Models.Responses;
public abstract class ApiBaseResponse
{
    public bool Success { get; set; }
    public string? Message { get; init; }
    public int StatusCode { get; init; }

    protected ApiBaseResponse(bool success, string? message = null, int statusCode = 200)
    {
        Success = success;
        //Support general feedback across all responses (not just NotFound).
        Message = message;
        StatusCode = statusCode;
    }

    public TResultType GetOkResult<TResultType>()
    {
        if (this is ApiOkResponse<TResultType> apiOkResponse)
        {
            return apiOkResponse.Result;
        }
        throw new InvalidOperationException($"Response type {this.GetType().Name} is not ApiOkResponse");
    }
}

public sealed class ApiOkResponse<TResult> : ApiBaseResponse
{
    public TResult Result { get; set; }
    public ApiOkResponse(TResult result, string? message = null) : base(true, message)
    {
        Result = result;
    }
}

// Abstract NotFound response
public abstract class ApiNotFoundResponse(string message)
    : ApiBaseResponse(false, message, StatusCodes.Status404NotFound)
{
}

// Concrete NotFound
public class ApiConcreteNotFoundResponse(string message) : ApiNotFoundResponse(message) { }

public class ApiFailedSaveResponse(string message)
    : ApiBaseResponse(false, message, StatusCodes.Status500InternalServerError)
{
}

public class ApiAlreadyExistsResponse(string message)
    : ApiBaseResponse(false, message, StatusCodes.Status409Conflict)
{
}