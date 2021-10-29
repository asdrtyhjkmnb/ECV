using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityTypeConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // говорим, что Id - это наш ключ
            builder.HasKey(x => x.Id);
        }
    }
}
