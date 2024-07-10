using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class NotificationRepository : AbstractRepository<Notification>
    {
        public NotificationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
