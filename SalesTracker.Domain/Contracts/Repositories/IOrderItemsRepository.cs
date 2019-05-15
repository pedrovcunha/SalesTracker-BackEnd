﻿using SalesTracker.Domain.Entities;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface IOrderItemsRepository : IGenericRepository<OrderItems, int>
    {
    }
}
