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
services.AddControllers();
var app = builder.Build();

// �������� ��� ��, ��� ����� ������������ ����������
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseRouting();
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
