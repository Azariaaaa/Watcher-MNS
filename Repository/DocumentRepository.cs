using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class DocumentRepository : AbstractRepository<Document>
    {
        public DocumentRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
