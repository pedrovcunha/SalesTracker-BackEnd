using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class PostcodesConfiguration : IEntityTypeConfiguration<Postcodes>
    {
        public void Configure(EntityTypeBuilder<Postcodes> builder)
        {
            builder.Property(e => e.Suburb).HasMaxLength(50);

            builder.Property(e => e.StateId).HasColumnName("StateID");

            builder.HasOne(d => d.State)
                .WithMany(p => p.Postcodes)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Postcodes_States");

            builder.Property(e => e.Latitude).HasColumnType("decimal(6,3)");

            builder.Property(e => e.Longitude).HasColumnType("decimal(6,3)");
        }
    }
}
