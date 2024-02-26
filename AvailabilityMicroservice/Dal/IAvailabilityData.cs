using AvailabilityMicroservice.Modellayer;

namespace AvailabilityMicroservice.Dal
{
    public interface IAvailabilityData
    {
        Task<Availability> CreateAsync(Availability availability);
        Task<IEnumerable<Availability>> GetAllAsync();
        Task<Availability> GetByIdAsync(string employeeId, DateTime availableDate);
        Task UpdateAsync(Availability availability);
        Task DeleteAsync(string employeeId, DateTime availableDate);
    }
}
