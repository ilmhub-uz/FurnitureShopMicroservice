using Cart.Api.Exceptions;

namespace Cart.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundException e)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsJsonAsync(new { error = e.Message });
        }
        catch (BadRequestException e)
        {
            httpContext.Response.StatusCode = e.ErrorCode;
            await httpContext.Response.WriteAsJsonAsync(new { error = e.Message });
        }
        catch (Exception e)
        {
            // _logger.LogError(e, "Internal error");
            throw;
        }
    }
}

public static class ErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}