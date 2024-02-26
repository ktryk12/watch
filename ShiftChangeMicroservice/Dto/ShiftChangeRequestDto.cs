using ShiftChangeMicroservice.Modellayer;

namespace ShiftChangeMicroservice.Dto
{
            public class ShiftChangeRequestDto
        {
            public int Id { get; set; }
            public string EmployeeId { get; set; }
            public int DesiredShiftId { get; set; }
            public string Reason { get; set; }
            public ShiftChangeStatus Status { get; set; }
        }
    

}
