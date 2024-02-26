using System.ComponentModel.DataAnnotations;

namespace ShiftChangeMicroservice.Modellayer
{
    public class ShiftChangeRequest
    {
        public int Id { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string EmployeeId { get; set; }
        public int DesiredShiftId { get; set; }
        public string Reason { get; set; }
        public ShiftChangeStatus Status { get; set; }

        // Methods for creating, approving, and denying requests
    }
}
