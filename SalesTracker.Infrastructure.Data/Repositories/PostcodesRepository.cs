using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class PostcodesRepository : GenericRepository<Postcodes>, IPostcodesRepository
    {
        public PostcodesRepository(SalestrackerdbContext pDbContext) : base(pDbContext)
        {

        }
    }
}
