using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationRepository _notificationRepository;

        public NotificationService(NotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public async Task AddAsync(Notification entity)
        {
            await _notificationRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _notificationRepository.DeleteAsync(id);
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _notificationRepository.GetAllAsync();
        }

        public async Task<Notification> GetByIdAsync(object id)
        {
            return await _notificationRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Notification entity)
        {
            await _notificationRepository.UpdateAsync(entity);
        }
    }
}
