using Microsoft.EntityFrameworkCore;
using SalesTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
     public class AddressesConfiguration : IEntityTypeConfiguration<Addresses>
    {
        public void Configure(EntityTypeBuilder<Addresses> builder)
        {
                builder.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.CountryId).HasColumnName("CountryID");

                builder.Property(e => e.StateId).HasColumnName("StateID");

                builder.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Adresses_Countries");

                builder.HasOne(d => d.PostCode)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PostCodeId)
                    .HasConstraintName("FK_Adresses_Postcodes");

                builder.HasOne(d => d.State)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Adresses_States");
            
        }
    }
}
