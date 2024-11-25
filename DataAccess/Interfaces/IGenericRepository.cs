using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, bool sortDescending = true);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<long> Count(Expression<Func<T, bool>> predicate);
    }
}
