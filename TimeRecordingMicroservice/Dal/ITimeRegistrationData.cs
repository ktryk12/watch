using TimeRecordingMicroservice.Modellayer;

namespace TimeRecordingMicroservice.Dal
{
    public interface ITimeRegistrationData
    {
        Task<TimeRegistration> AddTimeRegistrationAsync(TimeRegistration timeRegistration);
        Task<TimeRegistration> GetTimeRegistrationByIdAsync(int id);
        Task<IEnumerable<TimeRegistration>> GetAllTimeRegistrationsAsync();
        Task<TimeRegistration> UpdateTimeRegistrationAsync(TimeRegistration timeRegistration);
        Task<bool> DeleteTimeRegistrationAsync(int id);
    }
}
