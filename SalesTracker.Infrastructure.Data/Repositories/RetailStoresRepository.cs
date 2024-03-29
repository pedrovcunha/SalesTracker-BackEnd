﻿using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class RetailStoresRepository : GenericRepository<RetailStores>, IRetailStoresRepository
    {
        public RetailStoresRepository(Salestrackerdbcontext pDbContext) : base(pDbContext)
        {

        }
    }
}
