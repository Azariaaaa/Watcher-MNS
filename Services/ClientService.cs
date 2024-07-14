using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class ClientService : IClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task AddAsync(Client entity)
        {
            await _clientRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetByIdAsync(object id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Client entity)
        {
           await _clientRepository.UpdateAsync(entity);
        }
    }
}
