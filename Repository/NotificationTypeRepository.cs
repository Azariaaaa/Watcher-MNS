using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;

namespace WatchMNS.Repository
{
    public class NotificationTypeRepository : AbstractRepository<NotificationType>, INotificationTypeRepository
    {
        public NotificationTypeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
