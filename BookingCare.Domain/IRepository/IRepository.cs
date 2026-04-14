using Microsoft.EntityFrameworkCore;

namespace BookingCare.Domain.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T newEntity);
        T Update(T updateEntity);
        bool DeleteAsync(T deleteEntity);
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
        Task<IList<T>> GetAllAsync();
        IQueryable<T> QueryableAsync();
        Task AddRangeAsync(List<T> entites);
    }
}
