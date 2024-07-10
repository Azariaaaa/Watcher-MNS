using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly DocumentTypeRepository _documentTypeRepository;

        public DocumentTypeService(DocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }
        public async Task AddAsync(DocumentType entity)
        {
            await _documentTypeRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _documentTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DocumentType>> GetAllAsync()
        {
            return await _documentTypeRepository.GetAllAsync();
        }

        public async Task<DocumentType> GetByIdAsync(object id)
        {
            return await _documentTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DocumentType entity)
        {
            await _documentTypeRepository.UpdateAsync(entity);
        }
    }
}
