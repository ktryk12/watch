namespace AvailabilityMicroservice.Dto
{
    public class AvailabilityDto
    {
        public string EmployeeId { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan AvailableTime { get; set; }

       
    }

}
