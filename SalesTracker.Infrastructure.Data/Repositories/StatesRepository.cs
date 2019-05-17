using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class StatesRepository : GenericRepository<States>, IStatesRepository
    {
        public StatesRepository(Salestrackerdbcontext pDbContext) : base(pDbContext)
        {

        }
    }
}
