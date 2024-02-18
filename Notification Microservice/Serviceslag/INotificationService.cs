using Notification_Microservice.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification_Microservice.Serviceslag
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync();
        Task<NotificationDto> GetNotificationByIdAsync(int notificationId);
        Task CreateNotificationAsync(NotificationDto notificationDto);
        Task UpdateNotificationAsync(int notificationId, NotificationDto notificationDto);
        Task DeleteNotificationAsync(int notificationId);
    }
}
