using SalesTracker.Domain.Entities;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface IOrdersRepository :  IGenericRepository<Orders, int>
    {
    }
}
