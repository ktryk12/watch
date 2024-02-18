using Notification_Microservice.Dal;
using Notification_Microservice.Dto;
using Notification_Microservice.DtoConverter;
using Notification_Microservice.Modellayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification_Microservice.Serviceslag
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationData _notificationData;

        public NotificationService(INotificationData notificationData)
        {
            _notificationData = notificationData;
        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync()
        {
            var notifications = await _notificationData.GetAllNotificationsAsync();
            return notifications.Select(NotificationConverter.ToDto);
        }

        public async Task<NotificationDto> GetNotificationByIdAsync(int notificationId)
        {
            var notification = await _notificationData.GetNotificationByIdAsync(notificationId);
            return notification != null ? NotificationConverter.ToDto(notification) : null;
        }

        public async Task CreateNotificationAsync(NotificationDto notificationDto)
        {
            var notification = NotificationConverter.FromDtoForCreation(notificationDto);
            await _notificationData.AddNotificationAsync(notification);
        }

        public async Task UpdateNotificationAsync(int notificationId, NotificationDto notificationDto)
        {
            var notification = await _notificationData.GetNotificationByIdAsync(notificationId);
            if (notification != null)
            {
                // Opdater kun de felter, der kan ændres
                notification.Message = notificationDto.Message;
                notification.IsRead = notificationDto.IsRead;
                // SentTime opdateres ikke, da det repræsenterer oprindelsestidspunktet
                await _notificationData.UpdateNotificationAsync(notification);
            }
        }

        public async Task DeleteNotificationAsync(int notificationId)
        {
            await _notificationData.DeleteNotificationAsync(notificationId);
        }
    }
}
