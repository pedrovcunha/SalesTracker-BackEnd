using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class RetailStoresConfiguration : IEntityTypeConfiguration<RetailStores>
    {
        public void Configure(EntityTypeBuilder<RetailStores> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.Address)
                .WithMany(p => p.RetailStores)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_RetailStore_Adresses");
        }
    }
}
