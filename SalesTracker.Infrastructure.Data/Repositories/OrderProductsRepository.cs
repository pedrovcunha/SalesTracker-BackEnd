using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class OrderProductsRepository : GenericRepository<OrderProducts>, IOrderProductsRepository
    {
        public OrderProductsRepository(SalestrackerdbContext pDbContext):base(pDbContext)
        {

        }
    }
}
