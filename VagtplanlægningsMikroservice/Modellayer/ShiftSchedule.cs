namespace ShiftScheduleService.Modellayer
{
   public class ShiftSchedule
   {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public TimeSpan BreakTime { get; set; } // Assuming 'pausetid' refers to break time during the shift
            public int EmployeeId { get; set; } // Reference to an employee
            public ShiftStatus Status { get; set; } // Using the ShiftStatus enum

            // Additional properties and methods as needed
   }

  
}
