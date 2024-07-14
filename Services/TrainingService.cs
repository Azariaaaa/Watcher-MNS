using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly TrainingRepository _trainingRepository;

        public TrainingService(TrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }
        public async Task AddAsync(Training entity)
        {
            await _trainingRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _trainingRepository.DeleteAsync(id);
        }

        public async Task<List<Training>> GetAllAsync()
        {
            return await _trainingRepository.GetAllAsync();
        }

        public async Task<Training> GetByIdAsync(object id)
        {
            return await _trainingRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Training entity)
        {
            await _trainingRepository.UpdateAsync(entity);
        }
    }
}
