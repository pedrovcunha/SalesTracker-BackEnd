using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class PromotionalAgenciesConfiguration : IEntityTypeConfiguration<PromotionalAgencies>
    {
        public void Configure(EntityTypeBuilder<PromotionalAgencies> builder)
        {
            builder.Property(e => e.AddressId).HasColumnName("AddressID");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.Address)
                .WithMany(p => p.PromotionalAgencies)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_PromotionAgencies_Adresses");
        }
    }
}
