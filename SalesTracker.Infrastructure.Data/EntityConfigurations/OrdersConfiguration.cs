using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.Property(e => e.Commission).HasColumnType("decimal(5, 4)");

            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.Property(e => e.TotalPrice).HasColumnType("money");

            builder.HasOne(d => d.RetailStore)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.RetailStoreId)
                .HasConstraintName("FK_Orders_RetailStore");

            builder.HasOne(d => d.SalesRepresentative)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.SalesRepresentativeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_SalesRepresentatives");
        }
    }
}
