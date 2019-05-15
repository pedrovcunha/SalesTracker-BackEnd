using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface IGenericRepository<TEntity, TIdType> where TEntity : class
    {
        void Add(TEntity pObj);
        TEntity GetById(TIdType pId);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>[] pExpressions, Expression<Func<TEntity, object>>[] pIncludeProperties = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> pFilter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> pOrderBy = null, string includeProperties = "");
        void Update(TEntity pObj);
        void Remove(TEntity pObj);
        TEntity DeleteById(TIdType pId);
        void Delete(TEntity pObj);
        EntityEntry<TEntity> Entry(TEntity entity);
    }
}
