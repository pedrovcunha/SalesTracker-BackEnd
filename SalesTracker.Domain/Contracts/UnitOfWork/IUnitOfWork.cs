using SalesTracker.Domain.Contracts.Repositories;
using System.Threading.Tasks;

namespace SalesTracker.Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Contracts IoC
        IAddressesRepository Addresses { get; }
        ICountriesRepository Countries { get; }
        IBrandCategoriesRepository ItemCategories { get; }
        IOrderProductsRepository OrderItems { get; }
        IOrdersRepository Orders { get; }
        IPeopleRepository People { get; }
        IPostcodesRepository Postcodes { get; }
        IPromotionalAgenciesRepository PromotionalAgencies { get; }
        IRetailStoresRepository RetailStores { get; }
        ISalesRepresentativesRepository SalesRepresentatives { get; }
        IStatesRepository States { get; }
        #endregion

        #region Methods
        
        void Dispose();

        #endregion
    }
}
