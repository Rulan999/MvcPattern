using CA.Application.Repositories;
using CA.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CA.Infrastructure
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected BaseDBContext _appDbContext;

        protected BaseRepository(BaseDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual T Add(T entity)
        {
            return _appDbContext
                .Add(entity)
                .Entity;
        }

        public async virtual Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appDbContext.Set<T>()
                .AsQueryable()
                .Where(predicate).ToListAsync();
        }

        public async virtual Task<T> GetAsync(int id)
        {
            return await _appDbContext.FindAsync<T>(id);
        }

        public async virtual Task<IEnumerable<T>> AllAsync()
        {
            return await _appDbContext.Set<T>()
                .AsQueryable()
                .ToListAsync();
        }

        public virtual T Update(T entity)
        {
            return _appDbContext.Update(entity)
                .Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
