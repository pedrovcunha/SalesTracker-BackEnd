using SalesTracker.Domain.Entities;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface IItemsRepository : IGenericRepository<Items, int>
    {
    }
}
