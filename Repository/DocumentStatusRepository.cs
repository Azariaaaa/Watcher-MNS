using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class DocumentStatusRepository : AbstractRepository<DocumentStatus>
    {
        public DocumentStatusRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
