using SalesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface ISalesRepository : IGenericRepository<Sales>
    {
    }
}
