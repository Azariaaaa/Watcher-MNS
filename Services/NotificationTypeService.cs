using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;

namespace WatchMNS.Services
{
    public class NotificationTypeService : INotificationTypeService
    {
        private readonly NotificationTypeRepository _notificationTypeRepository;

        public NotificationTypeService(NotificationTypeRepository notificationTypeRepository)
        {
            _notificationTypeRepository = notificationTypeRepository;
        }
        public async Task AddAsync(NotificationType entity)
        {
            await _notificationTypeRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await _notificationTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<NotificationType>> GetAllAsync()
        {
            return await _notificationTypeRepository.GetAllAsync();
        }

        public async Task<NotificationType> GetByIdAsync(object id)
        {
            return await _notificationTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(NotificationType entity)
        {
            await _notificationTypeRepository.UpdateAsync(entity);
        }
    }
}
