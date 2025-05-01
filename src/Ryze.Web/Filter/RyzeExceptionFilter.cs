using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ryze.Application.Exceptions;
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
            HandleKnownException(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        var ryzeException = context.Exception as RyzeException;

        var response = new ErrorResponseDto(ryzeException!.GetErrors());
        
        context.HttpContext.Response.StatusCode = ryzeException.StatusCode;

        context.Result = new ObjectResult(response);
    }
    
    private static void HandleKnownException(ExceptionContext context)
    {
        var response = new ErrorResponseDto([context.Exception.Message]);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        context.Result = new ObjectResult(response);
    }
}