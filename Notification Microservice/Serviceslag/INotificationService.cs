using Notification_Microservice.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification_Microservice.Serviceslag
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync();
        Task<NotificationDto> GetNotificationByIdAsync(int notificationId);
        Task<IEnumerable<NotificationDto>> GetNotificationByEmployeeIdAsync(string employeeId);
        Task<int> CreateNotificationAsync(CreateNotificationDto createNotificationDto);
        Task UpdateNotificationAsync(int notificationId, NotificationDto notificationDto);
        Task DeleteNotificationAsync(int notificationId);
    }
}
