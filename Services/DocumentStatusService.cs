using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class DocumentStatusService : IDocumentStatusService
    {
        private readonly DocumentStatusRepository _documentStatusRepository;

        public DocumentStatusService(DocumentStatusRepository documentStatusRepository)
        {
            _documentStatusRepository = documentStatusRepository;
        }
        public async Task AddAsync(DocumentStatus entity)
        {
            await _documentStatusRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _documentStatusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DocumentStatus>> GetAllAsync()
        {
            return await _documentStatusRepository.GetAllAsync();
        }

        public async Task<DocumentStatus> GetByIdAsync(object id)
        {
            return await _documentStatusRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DocumentStatus entity)
        {
            await _documentStatusRepository.UpdateAsync(entity);
        }
    }
}
