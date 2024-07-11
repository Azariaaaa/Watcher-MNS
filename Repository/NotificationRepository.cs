using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class NotificationRepository : AbstractRepository<Notification>
    {
        public NotificationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
