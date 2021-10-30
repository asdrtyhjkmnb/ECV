using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using DataAccess;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IECVContext).Assembly));
}); // инициализаци€ автомапперa
services.AddApplication();
services.AddDataAccess(builder.Configuration);
services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyMethod();
    });
}); //позвол€ет кому угодно и как угодно посылать нам запросы. ¬ последствии нужно создать правила
services.AddControllers();
var app = builder.Build();

// пайплайн или то, что будет использовать приложение
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseRouting();
app.UseEndpoints(points => points.MapControllers()); // роутинг маппитс€ на название контроллера и его методы

// инициализаци€ контекста
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<ECVCoreContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {

    }
}

app.Run();
