using SalesTracker.Domain.Entities;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface ICustomersRepository: IGenericRepository<Customers, int>
    {
    }
}
