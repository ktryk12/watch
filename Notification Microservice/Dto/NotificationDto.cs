﻿

namespace Notification_Microservice.Dto
{
    public class NotificationDto
    {
        public int NotificationId { get; set; } 

        public string EmployeeId { get; set; }

        public string Message { get; set; }

        public DateTime SentTime { get; set; }

        public bool IsRead { get; set; }
    }
}
