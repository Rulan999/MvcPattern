using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> AllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
