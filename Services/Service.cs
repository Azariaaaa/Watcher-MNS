using WatchMNS.Repository.Interfaces;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }
        public async Task DeleteAsync(object id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
