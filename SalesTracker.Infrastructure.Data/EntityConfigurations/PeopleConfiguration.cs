using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTracker.Domain.Entities;

namespace SalesTracker.Infrastructure.Data.EntityConfigurations
{
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.Property(e => e.Email).HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.MiddleName).HasMaxLength(50);

            builder.Property(e => e.MobileNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.SurName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Address)
                .WithMany(p => p.People)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_People_Adresses");
        }
    }
}
