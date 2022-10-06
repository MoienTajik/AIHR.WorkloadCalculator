using System.Text.Json.Serialization;
using AIHR.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEntityFrameworkCore();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomMiddleware();

WebApplication app = builder.Build();
app.UseGlobalExceptionHandler();
app.UseAutomaticDatabaseMigrator();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

await app.RunAsync(app.Lifetime.ApplicationStopped);