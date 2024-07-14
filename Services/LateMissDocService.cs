using Microsoft.EntityFrameworkCore;
using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Repository.Interfaces;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class LateMissDocService : ILateMissDocService
    {
        private readonly LateMissDocRepository _lateMissDocRepository;

        public LateMissDocService(LateMissDocRepository lateMissDocRepository)
        {
            _lateMissDocRepository = lateMissDocRepository;
        }
        public async Task AddAsync(LateMissDoc entity)
        {
            await _lateMissDocRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _lateMissDocRepository.DeleteAsync(id);
        }

        public IQueryable<LateMissDoc> GetAll()
        {
            return _lateMissDocRepository.GetAll();
        }

        public async Task<List<LateMissDoc>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<LateMissDoc> GetByIdAsync(object id)
        {
            return await _lateMissDocRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(LateMissDoc entity)
        {
            await _lateMissDocRepository.UpdateAsync(entity);
        }
    }
}
