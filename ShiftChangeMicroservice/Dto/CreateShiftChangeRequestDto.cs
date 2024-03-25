using ShiftChangeMicroservice.Modellayer;

namespace ShiftChangeMicroservice.Dto
{
    public class CreateShiftChangeRequestDto
    {
        public string EmployeeId { get; set; }
        public int DesiredShiftId { get; set; }
        public string Reason { get; set; }
        public ShiftChangeStatus Status { get; set; }
    }


}

