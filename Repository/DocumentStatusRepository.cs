using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class DocumentStatusRepository : AbstractRepository<DocumentStatus>
    {
        public DocumentStatusRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
