using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class LateMissService : ILateMissService
    {
        private readonly LateMissRepository _lateMissRepository;

        public LateMissService(LateMissRepository lateMissRepository)
        {
            _lateMissRepository = lateMissRepository;
        }
        public async Task AddAsync(LateMiss entity)
        {
            await _lateMissRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _lateMissRepository.DeleteAsync(id);
        }

        public async Task<List<LateMiss>> GetAllAsync()
        {
            return await _lateMissRepository.GetAllAsync();
        }

        public async Task<LateMiss> GetByIdAsync(object id)
        {
            return await _lateMissRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(LateMiss entity)
        {
            await _lateMissRepository.UpdateAsync(entity);
        }
    }
}
