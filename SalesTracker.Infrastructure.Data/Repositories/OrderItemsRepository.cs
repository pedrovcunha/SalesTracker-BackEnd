using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class OrderItemsRepository : GenericRepository<OrderItems>, IOrderItemsRepository
    {
        public OrderItemsRepository(SalestrackerdbContext pDbContext):base(pDbContext)
        {

        }
    }
}
