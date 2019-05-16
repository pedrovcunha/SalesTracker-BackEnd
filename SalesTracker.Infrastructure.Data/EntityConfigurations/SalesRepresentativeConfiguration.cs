using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class SalesRepresentativeConfiguration : IEntityTypeConfiguration<SalesRepresentatives>
    {
        public void Configure(EntityTypeBuilder<SalesRepresentatives> builder)
        {
            builder.Property(e => e.JobTitle).HasMaxLength(50);

            builder.HasOne(d => d.PromotionAgency)
                .WithMany(p => p.SalesRepresentatives)
                .HasForeignKey(d => d.PromotionAgencyId)
                .HasConstraintName("FK_SalesRepresentatives_PromotionAgencies");

            builder.HasOne(d => d.RetailStore)
                .WithMany(p => p.SalesRepresentatives)
                .HasForeignKey(d => d.RetailStoreId)
                .HasConstraintName("FK_SalesRepresentatives_RetailStores");
        }
    }
}
