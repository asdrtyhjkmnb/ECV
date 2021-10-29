using Application.Interfaces;
using DataAccess.EntityTypeConfigurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public sealed class ECVCoreContext : DbContext, IECVContext
    {
        public ECVCoreContext(DbContextOptions<ECVCoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(builder);
        }
        public DbSet<Person> Persons { get; set; }
    }
}
