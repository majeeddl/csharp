using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Instance = context.HttpContext.Request.Path,
            Title = "An error occured while processing - filter",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = exception.Message
        };
        
        // var errorResult = new
        // {
        //     error = "An error occured while processing - filter"
        // };

        context.Result = new ObjectResult(problemDetails);
        // {
        //     StatusCode = 500
        // };

        context.ExceptionHandled = true;
    }
}