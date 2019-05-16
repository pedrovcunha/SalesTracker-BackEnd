using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SalesTracker.Domain.Contracts.Repositories;
using SalesTracker.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesTracker.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal SalestrackerdbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(SalestrackerdbContext context)
        {
            _context = context;
            this._dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>[] pExpressions, Expression<Func<T, object>>[] pIncludeProperties = null)
        {
            if (pExpressions == null) throw new ArgumentNullException(nameof(pExpressions));
            if (pExpressions.Length == 0) throw new ArgumentException("EXCEPTION_ARGUMENT_CANNOT_BE_AN_EMPTY_COLLECTION", nameof(pExpressions));

            IQueryable<T> items = _dbSet;

            var predicate = PredicateBuilder.New<T>(true);

            foreach (var expression in pExpressions)
                predicate.And(expression);

            items = items.Where(predicate);

            if (pIncludeProperties != null)
            {
                items = pIncludeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            }

            return items;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

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

        public virtual T GetByID(object pId)
        {
            return _dbSet.Find(pId);
        }
        
        public virtual void Insert(T pEntity)
        {
            _dbSet.Add(pEntity);
        }

        public virtual void Delete(int pId)
        {
            T entityToDelete = _dbSet.Find(pId);
            Delete(entityToDelete);
        }

        public virtual void Delete(T pEntityToDelete)
        {
            if (_context.Entry(pEntityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(pEntityToDelete);
            }
            _dbSet.Remove(pEntityToDelete);
        }

        public virtual void Update(T pEntityToUpdate)
        {
            _dbSet.Attach(pEntityToUpdate);
            _context.Entry(pEntityToUpdate).State = EntityState.Modified;
        }

        public EntityEntry<T> Entry(T entity)
        {
            return _context.Entry(entity);
        }

        #region Async Methods
        public async Task<T> FindAsync(int pId)
        {
            return await _dbSet.FindAsync(pId);
        }

        public async Task<T> AddAsync(T pEntity)
        {
            await _dbSet.AddAsync(pEntity);
            return pEntity;
        }

        

                #endregion



    }
}
