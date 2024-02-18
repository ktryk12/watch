using TimeRecordingMicroservice.Dal;
using TimeRecordingMicroservice.Dto; 
using TimeRecordingMicroservice.Modellayer;
using TimeRecordingMicroservice.DtoConverter; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeRecordingMicroservice.Serviceslag
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRegistrationData _timeRegistrationData;

        public TimeService(ITimeRegistrationData timeRegistrationData)
        {
            _timeRegistrationData = timeRegistrationData;
        }

        public async Task<TimeRegistrationDto> AddTimeRegistrationAsync(TimeRegistrationDto dto)
        {
            var timeRegistration = TimeRegistrationsConverter.ToEntity(dto);
            var addedTimeRegistration = await _timeRegistrationData.AddTimeRegistrationAsync(timeRegistration);
            return TimeRegistrationsConverter.ToDto(addedTimeRegistration);
        }

        public async Task<TimeRegistrationDto> GetTimeRegistrationByIdAsync(int id)
        {
            var timeRegistration = await _timeRegistrationData.GetTimeRegistrationByIdAsync(id);
            return TimeRegistrationsConverter.ToDto(timeRegistration);
        }

        public async Task<IEnumerable<TimeRegistrationDto>> GetAllTimeRegistrationsAsync()
        {
            var timeRegistrations = await _timeRegistrationData.GetAllTimeRegistrationsAsync();
            return timeRegistrations.Select(TimeRegistrationsConverter.ToDto);
        }

        public async Task<TimeRegistrationDto> UpdateTimeRegistrationAsync(TimeRegistrationDto dto)
        {
            var timeRegistration = TimeRegistrationsConverter.ToEntity(dto);
            var updatedTimeRegistration = await _timeRegistrationData.UpdateTimeRegistrationAsync(timeRegistration);
            return TimeRegistrationsConverter.ToDto(updatedTimeRegistration);
        }

        public async Task<bool> DeleteTimeRegistrationAsync(int id)
        {
            return await _timeRegistrationData.DeleteTimeRegistrationAsync(id);
        }
    }
}
