using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly DocumentRepository _documentRepository;

        public DocumentService(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task AddAsync(Document entity)
        {
            await _documentRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _documentRepository.DeleteAsync(id);
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _documentRepository.GetAllAsync();
        }

        public async Task<Document> GetByIdAsync(object id)
        {
            return await _documentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Document entity)
        {
            await _documentRepository.UpdateAsync(entity);
        }
    }
}
