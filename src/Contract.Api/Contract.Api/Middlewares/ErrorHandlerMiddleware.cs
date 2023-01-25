using Contract.Api.Exceptions;

namespace Contract.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger logger;

    public ErrorHandlerMiddleware (RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke (HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (NotFoundException ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsJsonAsync (new { error = ex.Message});
        }
        catch (Exception ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            logger.LogError(ex,"internal server error");
        }
    }
}

public static class ErrorHandlerMiddlewareExtension
{
    public static void UseErrorHandlerMiddleware (this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}