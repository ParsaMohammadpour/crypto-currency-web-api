using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CryptoCurrency.WebApi.Filters;

public class ExceptionHandlerAttribute(ILogger<ExceptionHandlerAttribute> logger) : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        logger.LogError($"Exception has occured: {context.Exception}");

        var errors = new List<string> { "Internal server error" };

        var errorObj = Result.Fail(errors);

        context.Result = new BadRequestObjectResult(errorObj);
    }
}
