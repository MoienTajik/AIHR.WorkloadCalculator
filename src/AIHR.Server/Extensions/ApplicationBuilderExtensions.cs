using AIHR.Server.Middleware;

namespace AIHR.Server.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseAutomaticDatabaseMigrator(this IApplicationBuilder app)
    {
        app.UseMiddleware<AutomaticDatabaseMigratorMiddleware>();
    }
    
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}