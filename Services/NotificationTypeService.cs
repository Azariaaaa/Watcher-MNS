using Microsoft.EntityFrameworkCore;
using WatchMNS.Models;
using WatchMNS.Repository;
using WatchMNS.Repository.Interfaces;
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

        public IQueryable<NotificationType> GetAll()
        {
            return _notificationTypeRepository.GetAll();
        }

        public async Task<List<NotificationType>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
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
