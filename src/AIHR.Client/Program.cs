using AHR.Client;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient(Constants.AihrServerHttpClientName, opt =>
{
    var serverUrl = builder.Configuration.GetValue<string>("AIHR:Url");
    if (string.IsNullOrWhiteSpace(serverUrl))
    {
        throw new ArgumentNullException(nameof(serverUrl), "Server URL should have value in configuration.");
    }
    
    opt.BaseAddress = new(serverUrl);
});

WebApplication app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Course}/{action=Index}/{id?}");

await app.RunAsync(app.Lifetime.ApplicationStopped);