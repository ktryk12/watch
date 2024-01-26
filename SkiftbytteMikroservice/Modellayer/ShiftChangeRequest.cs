namespace ShiftChangeMicroservice.Modellayer
{
    public class ShiftChangeRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DesiredShiftId { get; set; }
        public string Reason { get; set; }
        public ShiftChangeStatus Status { get; set; }

        // Methods for creating, approving, and denying requests
    }
}
