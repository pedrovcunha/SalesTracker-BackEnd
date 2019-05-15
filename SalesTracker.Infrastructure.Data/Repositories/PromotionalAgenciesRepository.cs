using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    class PromotionalAgenciesRepository : GenericRepository<PromotionalAgencies>, IPromotionalAgenciesRepository
    {
        public PromotionalAgenciesRepository(SalestrackerdbContext pDbContext) : base(pDbContext)
        {

        }
    }
}
