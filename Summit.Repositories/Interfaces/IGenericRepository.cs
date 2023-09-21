using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Summit.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task<T> AddAsync(T entity);
        Task<bool> ExistAsync(string id);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllByAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
    }
}
