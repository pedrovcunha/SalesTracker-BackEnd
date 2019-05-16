using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class StatesConfiguration : IEntityTypeConfiguration<States>
    {
        public void Configure(EntityTypeBuilder<States> builder)
        {
            builder.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(5);

            builder.Property(e => e.Capital).HasMaxLength(30);

            builder.Property(e => e.CountryId).HasColumnName("CountryID");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(d => d.Country)
                .WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_States_Countries");
        }
    }
}
