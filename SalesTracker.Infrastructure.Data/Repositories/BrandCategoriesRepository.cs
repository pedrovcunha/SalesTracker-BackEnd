using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class BrandCategoriesRepository : GenericRepository<BrandCategory>, IBrandCategoriesRepository
    {
        public BrandCategoriesRepository(Salestrackerdbcontext pDbContext):base(pDbContext)
        {

        }
    }
}
