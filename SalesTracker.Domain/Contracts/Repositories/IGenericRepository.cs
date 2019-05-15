using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>>[] pExpressions, Expression<Func<T, object>>[] pIncludeProperties = null);
        IEnumerable<T> Get(Expression<Func<T, bool>> pFilter, Func<IQueryable<T>, IOrderedQueryable<T>> pOrderBy = null, string includeProperties = "");
        T GetByID(object pId);
        void Insert(T pEntity);
        void Delete(object pId);
        void Delete(T pEntityToDelete);
        void Update(T pEntityToUpdate);

        EntityEntry<T> Entry(T entity);
    }
}
