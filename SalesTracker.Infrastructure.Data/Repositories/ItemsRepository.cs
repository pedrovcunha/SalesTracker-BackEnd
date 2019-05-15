using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class ItemsRepository: GenericRepository<Items>, IItemsRepository
    {
        public ItemsRepository(SalestrackerdbContext pDbContext):base(pDbContext)
        {

        }
    }
}
