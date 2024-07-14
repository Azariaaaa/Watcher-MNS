using Microsoft.EntityFrameworkCore;
using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Repository.Interfaces;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class TrainingTypeService : ITrainingTypeService
    {
        private readonly TrainingTypeRepository _trainingTypeRepository;

        public TrainingTypeService(TrainingTypeRepository trainingTypeRepository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }
        public async Task AddAsync(TrainingType entity)
        {
            await _trainingTypeRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _trainingTypeRepository.DeleteAsync(id);
        }

        public IQueryable<TrainingType> GetAll()
        {
            return _trainingTypeRepository.GetAll();
        }

        public async Task<List<TrainingType>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<TrainingType> GetByIdAsync(object id)
        {
            return await _trainingTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TrainingType entity)
        {
            await _trainingTypeRepository.UpdateAsync(entity);
        }
    }
}
