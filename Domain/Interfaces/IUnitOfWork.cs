using Domain.Base;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IAsyncRepository<T> Repository<T>() where T : BaseEntity;
    }
}
