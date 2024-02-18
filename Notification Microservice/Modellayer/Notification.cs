using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notification_Microservice.Modellayer
{
    
    public class Notification
    {
      
        public int NotificationId { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string EmployeeId { get; set; } // Antager at EmployeeId er en string

       
        public string Message { get; set; }

        
        public DateTime SentTime { get; set; }

       
        public bool IsRead { get; set; }

        
    }
}
