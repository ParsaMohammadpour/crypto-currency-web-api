using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CryptoCurrency.WebApi.Filters;

public class ValidateModelAttribute(ILogger<ValidateModelAttribute> logger) : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.ModelState.IsValid) return;

        var errors = context.ModelState
            .AsEnumerable()
            .SelectMany(err => err.Value?.Errors.Select(e => e.ErrorMessage) ?? []).ToList();

        var apiError = Result.Fail(errors);

        context.Result = new BadRequestObjectResult(apiError);

        logger.LogError($"Model validation error has occured: {context.Result}");
    }
}