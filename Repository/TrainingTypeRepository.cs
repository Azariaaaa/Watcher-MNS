using Microsoft.EntityFrameworkCore;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class TrainingTypeRepository : ITrainingTypeRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<TrainingType> _dbSet;

        public TrainingTypeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TrainingType>();
        }

        public async Task<TrainingType> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TrainingType> GetAll()
        {
            return _dbSet;
        }

        public async Task AddAsync(TrainingType entity)
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

        public async Task UpdateAsync(TrainingType entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
