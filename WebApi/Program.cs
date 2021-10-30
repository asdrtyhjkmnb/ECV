using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;
using WebApi.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IECVContext).Assembly));
}); // ������������� ����������a
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
}); //��������� ���� ������ � ��� ������ �������� ��� �������. � ����������� ����� ������� �������

services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:44386/";
                    options.Audience = "ECVWebAPI";
                    options.RequireHttpsMetadata = false;
                });

services.AddControllers();
var app = builder.Build();

// �������� ��� ��, ��� ����� ������������ ����������, ����� ��������� ���������� ������� �� �������
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(points => points.MapControllers()); // ������� �������� �� �������� ����������� � ��� ������

// ������������� ���������
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
