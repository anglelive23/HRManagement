using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(EFContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dbSet.FirstOrDefaultAsync(predicate)!;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                        || ex is InvalidOperationException
                        || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            try
            {
                return predicate != null
                    ? _dbSet.Where(predicate).ToListAsync()
                    : _dbSet.ToListAsync();
            }
            catch (Exception ex) when (ex is ArgumentNullException
                        || ex is InvalidOperationException
                        || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public Task<bool> RemoveAsync(T entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException(nameof(entity));

                _dbSet.Remove(entity);
                return Task.FromResult(true);
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                return Task.FromResult(entity);
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
    }
}
