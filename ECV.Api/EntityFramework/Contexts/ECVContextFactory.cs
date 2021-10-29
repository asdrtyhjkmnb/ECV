using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECV.Api.EntityFramework.Contexts
{
    public class ECVContextFactory : IDesignTimeDbContextFactory<ECVContext>
    {
        public ECVContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var optionBuilder = new DbContextOptionsBuilder<ECVContext>();
            optionBuilder.UseNpgsql(configuration.GetConnectionString("ECVConnectionString"));
            return new ECVContext(optionBuilder.Options);
        }
    }
}
