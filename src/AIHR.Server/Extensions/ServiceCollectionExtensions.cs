using AIHR.Server.Database;
using AIHR.Server.Middleware;
using Microsoft.EntityFrameworkCore;

namespace AIHR.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCustomMiddleware(this IServiceCollection services)
    {
        services.AddScoped<AutomaticDatabaseMigratorMiddleware>();
        services.AddScoped<GlobalExceptionHandlerMiddleware>();
    }
    
    public static void AddEntityFrameworkCore(this IServiceCollection services)
    {
        services.AddDbContextPool<ApplicationDbContext>(options =>
        {
            options.UseSqlite(CreateSqliteConnectionString());
            options.EnableSensitiveDataLogging();
        });

        string CreateSqliteConnectionString()
        {
            const Environment.SpecialFolder localAppDataFolder = Environment.SpecialFolder.LocalApplicationData;
            var localAppDataPath = Environment.GetFolderPath(localAppDataFolder);
            var connectionString = Path.Join(localAppDataPath, "AIHR.db");

            return $"Data Source={connectionString}";
        }        
    }
}