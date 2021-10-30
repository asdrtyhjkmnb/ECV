using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Factories
{
    public class ECVCoreContextFactory : IDesignTimeDbContextFactory<ECVCoreContext>
    {
        public ECVCoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ECVCoreContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("ECVConnectionString"));
            return new ECVCoreContext(optionsBuilder.Options);
        }
    }
}
