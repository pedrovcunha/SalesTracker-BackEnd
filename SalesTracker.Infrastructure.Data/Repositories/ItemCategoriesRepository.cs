using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class ItemCategoriesRepository : GenericRepository<ItemCategories>, IItemCategoriesRepository
    {
        public ItemCategoriesRepository(SalestrackerdbContext pDbContext):base(pDbContext)
        {

        }
    }
}
