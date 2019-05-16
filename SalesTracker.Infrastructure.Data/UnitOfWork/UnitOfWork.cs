using Microsoft.EntityFrameworkCore;
using SalesTracker.Domain.Contracts.UnitOfWork;
using SalesTracker.Infrastructure.Data.Context;
using SalesTracker.Infrastructure.Data.Repositories;
using System;
using SalesTracker.Domain.Contracts;
using SalesTracker.Domain.Contracts.Repositories;

namespace SalesTracker.Infrastructure.Data.UnitOfWork
{
    // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly SalestrackerdbContext _context = new SalestrackerdbContext();
        private AddressesRepository _addressesRepository;
        private CountriesRepository _countriesRepository;
        private BrandCategoriesRepository _itemCategoriesRepository;
        private ProductssRepository _itemsRepository;
        private OrderProductsRepository _orderItemsRepository;
        private OrdersRepository _ordersRepository;
        private PeopleRepository _peopleRepository;
        private PostcodesRepository _postcodesRepository;
        private PromotionalAgenciesRepository _promotionalAgenciesRepository;
        private RetailStoresRepository _retailStoresRepository;
        private SalesRepresentativesRepository _salesRepresentativesRepository;
        private StatesRepository _statesRepository;
        

        public IAddressesRepository Addresses => _addressesRepository ?? (_addressesRepository = new AddressesRepository(_context));
        public ICountriesRepository Countries => _countriesRepository ?? (_countriesRepository = new CountriesRepository(_context));
        public IBrandCategoriesRepository ItemCategories => _itemCategoriesRepository ?? (_itemCategoriesRepository = new BrandCategoriesRepository(_context));
        public IProductRepository Items => _itemsRepository ?? (_itemsRepository = new ProductssRepository(_context));
        public IOrderProductsRepository OrderItems => _orderItemsRepository ?? (_orderItemsRepository = new OrderProductsRepository(_context));
        public IOrdersRepository Orders => _ordersRepository ?? (_ordersRepository = new OrdersRepository(_context));
        public IPeopleRepository People=> _peopleRepository ?? (_peopleRepository = new PeopleRepository(_context));
        public IPostcodesRepository Postcodes => _postcodesRepository ?? (_postcodesRepository = new PostcodesRepository(_context));
        public IPromotionalAgenciesRepository PromotionalAgencies => _promotionalAgenciesRepository ?? (_promotionalAgenciesRepository = new PromotionalAgenciesRepository(_context));
        public IRetailStoresRepository RetailStores => _retailStoresRepository ?? (_retailStoresRepository = new RetailStoresRepository(_context));
        public ISalesRepresentativesRepository SalesRepresentatives => _salesRepresentativesRepository ?? (_salesRepresentativesRepository = new SalesRepresentativesRepository(_context));
        public IStatesRepository States => _statesRepository ?? (_statesRepository = new StatesRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
