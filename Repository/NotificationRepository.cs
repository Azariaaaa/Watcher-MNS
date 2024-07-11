using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class NotificationRepository : AbstractRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
