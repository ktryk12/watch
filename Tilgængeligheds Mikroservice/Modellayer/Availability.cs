namespace AvailabilityMicroservice.Modellayer
{
    public class Availability
    {
        public int EmployeeId { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan AvailableTime { get; set; }

    }
}
