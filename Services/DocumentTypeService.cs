using Microsoft.EntityFrameworkCore;
using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Repository.Interfaces;
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

        public IQueryable<DocumentType> GetAll()
        {
            return _documentTypeRepository.GetAll();
        }

        public async Task<List<DocumentType>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
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
