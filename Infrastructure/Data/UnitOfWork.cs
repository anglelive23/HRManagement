using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _context;

        public UnitOfWork(EFContext context)
        {
            _context = context;
        }

        public IAsyncRepository<T> Repository<T>() where T : BaseEntity
            => new RepositoryBase<T>(_context);

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows;

            }
            catch (Exception ex) when (ex is DbUpdateException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
    }
}
