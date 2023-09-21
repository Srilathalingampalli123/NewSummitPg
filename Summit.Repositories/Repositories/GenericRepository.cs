using Microsoft.EntityFrameworkCore;
using Summit.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Summit.Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        protected DbContext dbContext;
        protected DbSet<T> dbset;
        public GenericRepository(DbContext context, bool isMoc = false)
        {
            dbContext = context;
            dbset = dbContext.Set<T>();
            if (!isMoc)
            {
                dbContext.ChangeTracker.LazyLoadingEnabled = false;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            T entity = await dbset.FindAsync(id);
            dbset.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }

        public async Task<bool> ExistAsync(string id)
        {
            T entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).ToListAsync<T>();
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync<T>();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
