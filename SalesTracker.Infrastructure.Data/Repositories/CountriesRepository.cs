using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class CountriesRepository: GenericRepository<Countries>, ICountriesRepository
    {
        public CountriesRepository(Salestrackerdbcontext pDbContext) : base(pDbContext)
        {

        }
    }
}
