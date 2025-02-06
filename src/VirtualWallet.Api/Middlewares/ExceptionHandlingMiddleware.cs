using FluentValidation;
using System.Text.Json;
using Microsoft.Extensions.Localization;

namespace VirtualWallet.WebApi.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IStringLocalizer<ExceptionHandlingMiddleware> _localizer;


    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IStringLocalizer<ExceptionHandlingMiddleware> localizer
    )
    {
        _next = next;
        _logger = logger;
        _localizer = localizer;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var errors = ex.Errors.Select(e => new { field = e.PropertyName, error = e.ErrorMessage });

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                message = _localizer["ValidationError"],
                errors
            }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = "Внутренняя ошибка сервера" });
        }
    }
}