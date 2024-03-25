using TimeRecordingMicroservice.Modellayer;

namespace TimeRecordingMicroservice.Dal
{
    public interface ITimeRegistrationData
    {
        Task<TimeRegistration> AddTimeRegistrationAsync(TimeRegistration timeRegistration);
        Task<TimeRegistration> GetTimeRegistrationByIdAsync(int id);
        Task<IEnumerable<TimeRegistration>> GetAllTimeRegistrationsAsync();
        Task<IEnumerable<TimeRegistration>> GetTimeRegistrationsByEmployeeIdAsync(string employeeId);
        Task<TimeRegistration> UpdateTimeRegistrationAsync(TimeRegistration timeRegistration);
        Task<bool> DeleteTimeRegistrationAsync(int id);
    }
}
