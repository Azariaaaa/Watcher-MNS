using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class DocumentTypeRepository : AbstractRepository<DocumentType>
    {
        public DocumentTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
