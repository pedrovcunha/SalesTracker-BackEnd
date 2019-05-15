using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class SalesRepresentativesRepository : GenericRepository<SalesRepresentatives>, ISalesRepresentativesRepository
    {
        public SalesRepresentativesRepository(SalestrackerdbContext pDbContext) : base(pDbContext)
        {

        }
    }
}
