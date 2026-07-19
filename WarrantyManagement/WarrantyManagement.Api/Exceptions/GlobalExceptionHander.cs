using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WarrantyManagement.Api.Exceptions;

public class GlobalExceptionHandler(
    IProblemDetailsService problemDetailsService)
    : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = exception switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            ArgumentException => StatusCodes.Status400BadRequest,
            InvalidOperationException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        var detail = httpContext.Response.StatusCode ==
                     StatusCodes.Status500InternalServerError
            ? "An unexpected error occurred."
            : exception.Message;

        return problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Status = httpContext.Response.StatusCode,
                    Type = exception.GetType().Name,
                    Title = "An error occurred",
                    Detail = detail,
                    Instance = httpContext.Request.Path
                }
            });
    }
}