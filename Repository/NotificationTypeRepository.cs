using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Repository
{
    public class NotificationTypeRepository : AbstractRepository<NotificationType>
    {
        public NotificationTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
