using Microsoft.EntityFrameworkCore;
using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Repository.Interfaces;
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

        public IQueryable<DocumentStatus> GetAll()
        {
            return _documentStatusRepository.GetAll();
        }

        public async Task<List<DocumentStatus>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
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
