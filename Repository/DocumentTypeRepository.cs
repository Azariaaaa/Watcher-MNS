using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class DocumentTypeRepository : AbstractRepository<DocumentType>
    {
        public DocumentTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
