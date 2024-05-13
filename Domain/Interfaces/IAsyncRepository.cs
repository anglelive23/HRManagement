using Domain.Base;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
    }
}
