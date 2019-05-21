using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class OrderProductsConfiguration : IEntityTypeConfiguration<OrderProducts>
    {
        public void Configure(EntityTypeBuilder<OrderProducts> builder)
        {
            builder.HasKey(e => new { e.OrderOrderId, e.ProductProductId });

            builder.HasIndex(e => new { e.OrderOrderId, e.ProductProductId })
                .HasName("IX_OrderItems");

            builder.Property(e => e.OrderOrderId).HasColumnName("Order_OrderId");

            builder.Property(e => e.ProductProductId).HasColumnName("Product_ProductId");

            builder.HasOne(d => d.ProductProduct)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProducts_Products");

            builder.HasOne(d => d.OrderOrder)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderIProducts_Orders");
        }
    }
}
