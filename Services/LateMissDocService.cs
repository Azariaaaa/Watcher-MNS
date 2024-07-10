using WatchMNS.Models;
using WatchMNS.Repository;
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

        public async Task<IEnumerable<LateMissDoc>> GetAllAsync()
        {
            return await _lateMissDocRepository.GetAllAsync();
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
