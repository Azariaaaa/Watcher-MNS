using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class DocumentRepository : AbstractRepository<Document>
    {
        public DocumentRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
