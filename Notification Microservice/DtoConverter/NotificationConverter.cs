using Notification_Microservice.Modellayer;
using Notification_Microservice.Dto;

namespace Notification_Microservice.DtoConverter
{
    public static class NotificationConverter
    {
        public static NotificationDto ToDto(Notification notification)
        {
            return new NotificationDto
            {
                NotificationId = notification.NotificationId,
                EmployeeId = notification.EmployeeId,
                Message = notification.Message,
                SentTime = notification.SentTime,
                IsRead = notification.IsRead
            };
        }

        // Eksisterende metode til konvertering fra DTO til entitet
        public static Notification FromDto(NotificationDto notificationDto)
        {
            return new Notification
            {
                EmployeeId = notificationDto.EmployeeId,
                Message = notificationDto.Message,
                SentTime = notificationDto.SentTime,
                IsRead = notificationDto.IsRead
            };
        }

        // Tilføjet: Specifik metode til at håndtere oprettelse fra DTO
        public static Notification FromDtoForCreation(NotificationDto notificationDto)
        {
            return new Notification
            {
                EmployeeId = notificationDto.EmployeeId,
                Message = notificationDto.Message,
                SentTime = DateTime.UtcNow, // Sætter sendetiden til nuværende tidspunkt ved oprettelse
                IsRead = false // Antager at en ny notifikation ikke er læst
            };
        }
    }
}
