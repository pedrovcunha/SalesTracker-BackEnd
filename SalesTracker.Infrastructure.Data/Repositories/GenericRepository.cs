using Microsoft.EntityFrameworkCore;
using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal SalestrackerdbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(SalestrackerdbContext context)
        {
            _context = _context;
            this._dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object pId)
        {
            return _dbSet.Find(pId);
        }

        public virtual void Insert(TEntity pEntity)
        {
            _dbSet.Add(pEntity);
        }

        public virtual void Delete(object pId)
        {
            TEntity entityToDelete = _dbSet.Find(pId);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity pEntityToDelete)
        {
            if (_context.Entry(pEntityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(pEntityToDelete);
            }
            _dbSet.Remove(pEntityToDelete);
        }

        public virtual void Update(TEntity pEntityToUpdate)
        {
            _dbSet.Attach(pEntityToUpdate);
            _context.Entry(pEntityToUpdate).State = EntityState.Modified;
        }

        //public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>[] pExpressions, Expression<Func<TEntity, object>>[] pIncludeProperties = null)
        //{
        //    if (pExpressions == null) throw new ArgumentNullException(nameof(pExpressions));
        //    if (pExpressions.Length == 0) throw new ArgumentException(ApiExceptionsMsg.EXCEPTION_ARGUMENT_CANNOT_BE_AN_EMPTY_COLLECTION, nameof(pExpressions));

        //    IQueryable<TEntity> items = Context.Set<TEntity>();

        //    var predicate = PredicateBuilder.New<TEntity>(true);

        //    foreach (var expression in pExpressions)
        //        predicate.And(expression);

        //    items = items.Where(predicate);

        //    if (pIncludeProperties != null)
        //    {
        //        items = pIncludeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
        //    }

        //    return items;
        //}

        //public IQueryable<TEntity> GetAll()
        //{
        //    return Context.Set<TEntity>();
        //}

    }
}
