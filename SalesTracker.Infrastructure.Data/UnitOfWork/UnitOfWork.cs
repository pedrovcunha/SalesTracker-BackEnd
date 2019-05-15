using SalesTracker.Domain.Contracts.UnitOfWork;
using SalesTracker.Infrastructure.Data.Context;
using SalesTracker.Infrastructure.Data.Repositories;
using System;

namespace SalesTracker.Infrastructure.Data.UnitOfWork
{
    // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly SalestrackerdbContext _Context = new SalestrackerdbContext();
        private AddressesRepository _addressesRepository;
        private CountriesRepository _countriesRepository;
        private CustomersRepository _customersRepository;
        private ItemCategoriesRepository _itemCategoriesRepository;
        private ItemsRepository _itemsRepository;
        private OrderItemsRepository _orderItemsRepository;
        private OrdersRepository _rdersRepository;
        private PeopleRepository _peopleRepository;
        private PostcodesRepository _postcodesRepository;
        private PromotionalAgenciesRepository _promotionalAgenciesRepository;
        private RetailStoresRepository _retailStoresRepository;
        private SalesRepresentativesRepository _salesRepresentativesRepository;
        private StatesRepository _statesRepository;
            

    }
}
