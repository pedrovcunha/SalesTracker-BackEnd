using SalesTracker.Domain.Contracts.Repositories;
using System.Threading.Tasks;

namespace SalesTracker.Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Contracts IoC
        IAddressRepository Addresses { get; }
        ICountriesRepository Countries { get; }
        ICustomersRepository Customers { get; }
        IItemCategoriesRepository ItemCategories { get; }
        IOrderItemsRepository OrderItems { get; }
        IOrdersRepository Orders { get; }
        IPeopleRepository People { get; }
        IPostcodesRepository Postcodes { get; }
        IPromotionalAgenciesRepository PromotionalAgencies { get; }
        IRetailStoresRepository RetailStores { get; }
        ISalesRepresentativesRepository SalesRepresentatives { get; }
        IStatesRepository States { get; }
        #endregion

        #region Commits

        Task<int> CommitAsync(bool pIgnoreUnchangedItems = true);
        //Task<Audit> CommitAndReturnAuditAsync(bool pIgnoreUnchangedItems = true);
        void Dispose();

        #endregion
    }
}
