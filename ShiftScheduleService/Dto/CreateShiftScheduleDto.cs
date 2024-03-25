using ShiftScheduleMicroService.Modellayer;

namespace ShiftScheduleMicroService.Dto
{
    public class CreateShiftScheduleDto
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public string EmployeeId { get; set; }
        public ShiftStatus Status { get; set; }
    }
}
