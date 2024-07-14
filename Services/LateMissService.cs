using Microsoft.EntityFrameworkCore;
using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Repository.Interfaces;
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

        public IQueryable<LateMiss> GetAll()
        {
            return _lateMissRepository.GetAll();
        }

        public async Task<List<LateMiss>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<LateMiss> GetByIdAsync(object id)
        {
            return await _lateMissRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(LateMiss entity)
        {
            await _lateMissRepository.UpdateAsync(entity);
        }

        public async Task<List<LateMiss>> GetLateMissesFromUser(Client client, string lateMissType) 
        { 
            return await GetAll()
                .Where(x => (x.Client == client) && (x.LateMissType == "Absence"))
                .Include(x => x.lateMissStatus)
                .ToListAsync();
        }
    }
}
