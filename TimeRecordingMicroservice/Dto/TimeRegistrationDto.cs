namespace TimeRecordingMicroservice.Dto
{
    public class TimeRegistrationDto
    {
        public int TimeRegistrationId { get; set; }
        public string Username { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public double TotalWorkHours { get; set; }
        public double OvertimeHours { get; set; }
    }
}
