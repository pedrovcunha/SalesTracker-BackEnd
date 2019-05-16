using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class AddressesRepository : GenericRepository<Addresses>, IAddressesRepository
    {
        public AddressesRepository(SalestrackerdbContext pDbContext) : base(pDbContext)
        {

        }
    }
}
