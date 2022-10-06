using AIHR.Server.Database;
using Microsoft.EntityFrameworkCore;

namespace AIHR.Server.Middleware;

public class AutomaticDatabaseMigratorMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        var db = httpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
        
        if (db.Database.IsRelational())
        {
            await db.Database.MigrateAsync(httpContext.RequestAborted);
        }

        await next(httpContext);
    }
}