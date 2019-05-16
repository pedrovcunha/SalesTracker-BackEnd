using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Contracts.UnitOfWork;
using SalesTracker.Infrastructure.Data.Context;
using SalesTracker.Infrastructure.Data.Repositories;
using SalesTracker.Infrastructure.Data.UnitOfWork;


namespace SalesTracker.BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAddressesRepository, AddressesRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IBrandCategoriesRepository, BrandCategoriesRepository>();
            services.AddScoped<IProductRepository, ProductssRepository>();
            services.AddScoped<IOrderProductsRepository, OrderProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IPostcodesRepository, PostcodesRepository>();
            services.AddScoped<IPromotionalAgenciesRepository, PromotionalAgenciesRepository>();
            services.AddScoped<IRetailStoresRepository, IRetailStoresRepository>();
            services.AddScoped<ISalesRepresentativesRepository, SalesRepresentativesRepository>();
            services.AddScoped<IStatesRepository, StatesRepository>();
            
            //AddDefaultRepositories(services);



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add responseCaching in thr browser.
            services.AddResponseCaching();

            //var connection = "Server=salestrackerdbinstance.caqbw1dpdyst.ap-southeast-2.rds.amazonaws.com; Initial Catalog=salestrackerdb; User ID = salesTrackerdb; Password = tEh2GktSeoh2; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=True;";
            services.AddDbContext<SalestrackerdbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SalesTrackerDatabse")));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        //public static void AddDefaultRepositories(this IServiceCollection services)
        //{
        //    services.TryAdd(ServiceDescriptor.Scoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)));
        //}
    }
}
