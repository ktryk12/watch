using System.ComponentModel.DataAnnotations;

namespace ShiftScheduleMicroService.Modellayer
{
   public class ShiftSchedule
   {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public TimeSpan BreakTime { get; set; } // Assuming 'pausetid' refers to break time during the shift
            [Required]
            [StringLength(4, MinimumLength = 4)] 
            public string EmployeeId { get; set; }
            public ShiftStatus Status { get; set; } // Using the ShiftStatus enum

           
   }

  
}
