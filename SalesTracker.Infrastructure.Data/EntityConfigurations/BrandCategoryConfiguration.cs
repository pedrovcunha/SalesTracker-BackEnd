using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class BrandCategoryConfiguration : IEntityTypeConfiguration<BrandCategory>
    {
        public void Configure(EntityTypeBuilder<BrandCategory> builder)
        {
            builder.Property(e => e.Description).HasMaxLength(50);

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.BrandManager)
                .WithMany(p => p.BrandCategory)
                .HasForeignKey(d => d.BrandManagerId)
                .HasConstraintName("FK_BrandCategory_People");
        }
    }
}
