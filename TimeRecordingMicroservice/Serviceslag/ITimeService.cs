using TimeRecordingMicroservice.Dto;

namespace TimeRecordingMicroservice.Serviceslag
{
    public interface ITimeService
    {
        Task<TimeRegistrationDto> AddTimeRegistrationAsync(TimeRegistrationDto dto);
        Task<TimeRegistrationDto> GetTimeRegistrationByIdAsync(int id);
        Task<IEnumerable<TimeRegistrationDto>> GetAllTimeRegistrationsAsync();
        Task<TimeRegistrationDto> UpdateTimeRegistrationAsync(TimeRegistrationDto dto);
        Task<bool> DeleteTimeRegistrationAsync(int id);

    }
}
