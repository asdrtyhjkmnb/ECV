using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ECVConnectionString"];
            services.AddDbContext<ECVCoreContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IECVContext>(provider => provider.GetService<ECVCoreContext>());
            return services;
        }
    }
}
