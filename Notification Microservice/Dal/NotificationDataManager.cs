using Microsoft.EntityFrameworkCore;
using Notification_Microservice.Modellayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification_Microservice.Dal
{
    public class NotificationDataManager : INotificationData
    {
        private readonly ServiceContext _context;

        public NotificationDataManager(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _context.Notification.ToListAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(int notificationId)
        {
            return await _context.Notification
                .FirstOrDefaultAsync(n => n.NotificationId == notificationId);
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            _context.Notification.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(int notificationId)
        {
            var notification = await GetNotificationByIdAsync(notificationId);
            if (notification != null)
            {
                _context.Notification.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }
    }
}
