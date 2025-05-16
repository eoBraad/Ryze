using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ryze.Infrastructure.Exceptions;
using Ryze.Application.Responses;

namespace Ryze.Web.Filter;

public class RyzeExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is RyzeException)
        {
            HandleProjectException(context);
        }
        else
        {
            HandleUnknownException(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        var ryzeException = context.Exception as RyzeException;

        var response = new ErrorResponseDto(ryzeException!.GetErrors());
        
        context.HttpContext.Response.StatusCode = ryzeException.StatusCode;

        context.Result = new ObjectResult(response);
    }
    
    private static void HandleUnknownException(ExceptionContext context)
    {
        var response = new ErrorResponseDto(["Unknown Error, please try again later."]);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        context.Result = new ObjectResult(response);
    }
}