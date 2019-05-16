using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class ProductssRepository: GenericRepository<Products>, IProductRepository
    {
        public ProductssRepository(SalestrackerdbContext pDbContext):base(pDbContext)
        {

        }
    }
}
