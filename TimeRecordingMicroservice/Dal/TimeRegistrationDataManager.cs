using TimeRecordingMicroservice.Modellayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeRecordingMicroservice.Dal
{
    public class TimeRegistrationDataManager : ITimeRegistrationData
    {
        private readonly ServiceContext _context;

        public TimeRegistrationDataManager(ServiceContext context)
        {
            _context = context;
        }

        public async Task<TimeRegistration> AddTimeRegistrationAsync(TimeRegistration timeRegistration)
        {
            _context.TimeRegistration.Add(timeRegistration);
            await _context.SaveChangesAsync();
            return timeRegistration;
        }

        public async Task<IEnumerable<TimeRegistration>> GetAllTimeRegistrationsAsync()
        {
            return await _context.TimeRegistration.ToListAsync();
        }

        public async Task<TimeRegistration> GetTimeRegistrationByIdAsync(int id)
        {
            return await _context.TimeRegistration
                .FirstOrDefaultAsync(tr => tr.TimeRegistrationId == id);
        }

        public async Task<TimeRegistration> UpdateTimeRegistrationAsync(TimeRegistration timeRegistration)
        {
            _context.TimeRegistration.Update(timeRegistration);
            await _context.SaveChangesAsync();
            return timeRegistration;
        }

        public async Task<bool> DeleteTimeRegistrationAsync(int id)
        {
            var timeRegistration = await _context.TimeRegistration
                .FindAsync(id);
            if (timeRegistration == null)
            {
                return false;
            }
            _context.TimeRegistration.Remove(timeRegistration);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
