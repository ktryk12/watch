using Microsoft.EntityFrameworkCore;
using ShiftScheduleMicroService.Modellayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftScheduleMicroService.Dal
{
    public class ShiftScheduleDataManager : IShiftScheduleData
    {
        private readonly ServiceContext _context;

        public ShiftScheduleDataManager(ServiceContext context)
        {
            _context = context;
        }

        public async Task<ShiftSchedule> AddShiftScheduleAsync(ShiftSchedule shiftSchedule)
        {
            _context.ShiftSchedule.Add(shiftSchedule);
            await _context.SaveChangesAsync();
            return shiftSchedule;
        }

        public async Task<ShiftSchedule> GetShiftScheduleByIdAsync(int id)
        {
            return await _context.ShiftSchedule.FindAsync(id);
        }

        public async Task<IEnumerable<ShiftSchedule>> GetAllShiftSchedulesAsync()
        {
            return await _context.ShiftSchedule.ToListAsync();
        }

        public async Task<ShiftSchedule> UpdateShiftScheduleAsync(ShiftSchedule shiftSchedule)
        {
            var existingShift = await _context.ShiftSchedule.FindAsync(shiftSchedule.Id);
            if (existingShift != null)
            {
                _context.Entry(existingShift).CurrentValues.SetValues(shiftSchedule);
                await _context.SaveChangesAsync();
            }
            return existingShift;
        }

        public async Task<bool> DeleteShiftScheduleAsync(int id)
        {
            var shiftSchedule = await _context.ShiftSchedule.FindAsync(id);
            if (shiftSchedule != null)
            {
                _context.ShiftSchedule.Remove(shiftSchedule);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
