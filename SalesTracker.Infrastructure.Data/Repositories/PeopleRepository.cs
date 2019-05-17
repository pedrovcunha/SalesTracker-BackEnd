using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class PeopleRepository : GenericRepository<People>, IPeopleRepository
    {
        public PeopleRepository(Salestrackerdbcontext pDbContext): base(pDbContext)
        {

        }
    }
}
