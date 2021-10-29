using ECV.Api.EntityFramework.Entities.Schemas.Core;
using Microsoft.EntityFrameworkCore;

namespace ECV.Api.EntityFramework.Contexts
{
    public class ECVContext : DbContext
    {
        public ECVContext(DbContextOptions<ECVContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region Core
        public DbSet<Person> Persons { get; set; }
        #endregion
    }
}
