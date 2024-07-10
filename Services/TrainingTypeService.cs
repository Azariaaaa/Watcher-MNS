using WatchMNS.Models;
using WatchMNS.Repository;
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

        public async Task<IEnumerable<TrainingType>> GetAllAsync()
        {
            return await _trainingTypeRepository.GetAllAsync();
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
