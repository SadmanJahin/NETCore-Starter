using DataAccess.DataContext;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _databaseContext;
        private DbSet<T> _dbSet => _databaseContext.Set<T>();
        public IQueryable<T> Entities => _dbSet;
        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, bool sortDescending = true)
        {
            var query = _dbSet.Where(predicate);
            if (sortDescending)
            {
                query = query.OrderByDescending(orderBy);
            }
            else
            {
                query = query.OrderBy(orderBy);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);
            var result = await includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();
            return result;
        }

        public async Task<long> Count(Expression<Func<T, bool>> predicate)
        {
            long count = await _dbSet.CountAsync(predicate);
            return count;
        }
    }
}
