using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class CountriesConfiguration: IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {
                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30);
        }
    }
}
