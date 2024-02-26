using AvailabilityMicroservice.Modellayer;
using Microsoft.EntityFrameworkCore;


namespace AvailabilityMicroservice.Dal
{
    public class AvailabilityDataManager : IAvailabilityData
    {
        private readonly ServiceContext _context;

        public AvailabilityDataManager(ServiceContext context)
        {
            _context = context;
        }

        public async Task<Availability> CreateAsync(Availability availability)
        {
            _context.Availability.Add(availability);
            await _context.SaveChangesAsync();
            return availability;
        }


        public async Task<IEnumerable<Availability>> GetAllAsync()
        {
            return await _context.Availability.ToListAsync();
        }

        public async Task<Availability> GetByIdAsync(string employeeId, DateTime availableDate)
        {
            return await _context.Availability
                .FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.AvailableDate == availableDate);
        }

        public async Task UpdateAsync(Availability availability)
        {
            _context.Entry(availability).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string employeeId, DateTime availableDate)
        {
            var availability = await _context.Availability
                .FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.AvailableDate == availableDate);
            if (availability != null)
            {
                _context.Availability.Remove(availability);
                await _context.SaveChangesAsync();
            }
        }
    }
}

