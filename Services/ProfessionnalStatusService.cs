using Microsoft.EntityFrameworkCore;
using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Repository.Interfaces;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class ProfessionnalStatusService : IProfessionnalStatusService
    {
        private readonly ProfessionnalStatusRepository _professionnalStatusRepository;

        public ProfessionnalStatusService(ProfessionnalStatusRepository professionnalStatusRepository)
        {
            _professionnalStatusRepository = professionnalStatusRepository;
        }
        public async Task AddAsync(ProfessionnalStatus entity)
        {
            await _professionnalStatusRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _professionnalStatusRepository.DeleteAsync(id);
        }

        public IQueryable<ProfessionnalStatus> GetAll()
        {
            return _professionnalStatusRepository.GetAll();
        }

        public async Task<List<ProfessionnalStatus>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<ProfessionnalStatus> GetByIdAsync(object id)
        {
            return await _professionnalStatusRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ProfessionnalStatus entity)
        {
            await _professionnalStatusRepository.UpdateAsync(entity);
        }
    }
}
