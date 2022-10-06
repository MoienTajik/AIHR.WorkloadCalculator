namespace AIHR.Server.Middleware;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<GlobalExceptionHandlerMiddleware>>();
            logger.LogError(ex, "An unhandled exception has occurred");
            
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await WriteResponseAsync(ex);
        }

        async Task WriteResponseAsync(Exception ex)
        {
            var response = new
            {
                Error = ex.Message.Replace(Environment.NewLine, " - ")
            };
            
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}