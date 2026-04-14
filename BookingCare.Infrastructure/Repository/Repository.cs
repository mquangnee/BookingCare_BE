using BookingCare.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T newEntity)
        {
            await _dbSet.AddAsync(newEntity);
            return newEntity;
        }

        public T Update(T updateEntity)
        {
            _dbSet.Update(updateEntity);
            return updateEntity;
        }

        public bool DeleteAsync(T deleteEntity)
        {
            var entity = _dbSet.Remove(deleteEntity);
            return entity != null;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> QueryableAsync()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
    }
}
