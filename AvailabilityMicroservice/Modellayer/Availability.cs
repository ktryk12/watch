using System.ComponentModel.DataAnnotations;

namespace AvailabilityMicroservice.Modellayer
{
    public class Availability
    {
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string EmployeeId { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan AvailableTime { get; set; }

    }
}
