using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SalesTracker.Domain.Contracts.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity pObj);
        //IQueryable<TEntity> GetAll();
        //IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>[] pExpressions, Expression<Func<TEntity, object>>[] pIncludeProperties = null);
        
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> pFilter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> pOrderBy = null, string includeProperties = "");
        TEntity GetByID(object pId);
        void Insert(TEntity pEntity);
        void Delete(object pId);
        void Delete(TEntity pEntityToDelete);
        void Update(TEntity pEntityToUpdate);

        //EntityEntry<TEntity> Entry(TEntity entity);
    }
}
