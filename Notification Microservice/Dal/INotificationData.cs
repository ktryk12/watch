using Notification_Microservice.Modellayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification_Microservice.Dal
{
    public interface INotificationData
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(int notificationId);
        Task<IEnumerable<Notification>> GetNotificationByEmployeeIdAsync(string employeeId);
        Task<Notification> AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int notificationId);
    }
}
