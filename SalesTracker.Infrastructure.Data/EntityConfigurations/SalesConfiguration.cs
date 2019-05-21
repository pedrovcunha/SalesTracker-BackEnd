using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.Property(e => e.Comission).HasColumnType("decimal(5, 4)");

            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.Property(e => e.TotalPrice).HasColumnType("money");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Sales_Products");

            builder.HasOne(d => d.RetailStore)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.RetailStoreId)
                .HasConstraintName("FK_Sales_RetailStores");

            builder.HasOne(d => d.SalesRepresentative)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.SalesRepresentativeId)
                .HasConstraintName("FK_Sales_SalesRepresentatives");

        }
    }
}
