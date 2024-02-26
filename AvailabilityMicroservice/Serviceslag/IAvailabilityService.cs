using AvailabilityMicroservice.Dto;

namespace AvailabilityMicroservice.Serviceslag
{
    public interface IAvailabilityService
    {
        Task<AvailabilityDto> CreateAvailabilityAsync(AvailabilityDto dto);
        Task<IEnumerable<AvailabilityDto>> GetAllAvailabilitiesAsync();
        Task<AvailabilityDto> GetAvailabilityByIdAsync(string employeeId, DateTime availableDate);
        Task UpdateAvailabilityAsync(AvailabilityDto dto);
        Task DeleteAvailabilityAsync(string employeeId, DateTime availableDate);
    }
}
