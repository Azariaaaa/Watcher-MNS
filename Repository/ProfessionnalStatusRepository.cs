using Microsoft.EntityFrameworkCore;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class ProfessionalStatusRepository : IProfessionnalStatusRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<ProfessionnalStatus> _dbSet;

        public ProfessionalStatusRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<ProfessionnalStatus>();
        }

        public async Task<ProfessionnalStatus> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<ProfessionnalStatus> GetAll()
        {
            return _dbSet;
        }

        public async Task AddAsync(ProfessionnalStatus entity)
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

        public async Task UpdateAsync(ProfessionnalStatus entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
