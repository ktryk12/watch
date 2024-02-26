namespace ShiftScheduleMicroService.Modellayer
{
    public enum ShiftStatus
    {
        Scheduled, // Vagt planlagt
        Completed, // Vagt afsluttet
        Cancelled, // Vagt annulleret
        Pending    // Vagt afventer godkendelse
    }

}
