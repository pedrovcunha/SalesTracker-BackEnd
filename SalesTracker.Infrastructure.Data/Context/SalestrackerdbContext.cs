using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.EntityConfigurations;


namespace SalesTracker.Infrastructure.Data.Context
{
    public partial class Salestrackerdbcontext : DbContext
    {
        public Salestrackerdbcontext()
        {
        }

        public Salestrackerdbcontext(DbContextOptions<Salestrackerdbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<BrandCategory> BrandCategory { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<OrderProducts> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Postcodes> Postcodes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<PromotionalAgencies> PromotionalAgencies { get; set; }
        public virtual DbSet<RetailStores> RetailStores { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesRepresentatives> SalesRepresentatives { get; set; }
        public virtual DbSet<States> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressesConfiguration());
            modelBuilder.ApplyConfiguration(new BrandCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new PostcodesConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionalAgenciesConfiguration());
            modelBuilder.ApplyConfiguration(new RetailStoresConfiguration());
            modelBuilder.ApplyConfiguration(new SalesConfiguration());
            modelBuilder.ApplyConfiguration(new SalesRepresentativeConfiguration());
            modelBuilder.ApplyConfiguration(new StatesConfiguration());

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Settings.ConnectionString);
            }
        }
    }
}
