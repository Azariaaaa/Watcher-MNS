using System.ComponentModel.DataAnnotations;

namespace WatchMNS.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
