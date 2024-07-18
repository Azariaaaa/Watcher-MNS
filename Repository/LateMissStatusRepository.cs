using Microsoft.EntityFrameworkCore;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class LateMissStatusRepository : ILateMissStatusRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<LateMissStatus> _dbSet;

        public LateMissStatusRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<LateMissStatus>();
        }

        public async Task<LateMissStatus> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<LateMissStatus> GetAll()
        {
            return _dbSet;
        }

        public async Task AddAsync(LateMissStatus entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(LateMissStatus entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
