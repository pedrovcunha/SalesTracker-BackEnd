using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(e => e.Description).HasMaxLength(50);

            builder.Property(e => e.Price).HasColumnType("money");

            builder.HasOne(d => d.BrandCategory)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandCategoryId)
                .HasConstraintName("FK_Products_BrandCategory");
        }
    }
}
