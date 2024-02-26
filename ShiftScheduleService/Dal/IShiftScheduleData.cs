using ShiftScheduleMicroService.Modellayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftScheduleMicroService.Dal
{
    public interface IShiftScheduleData
    {
        Task<ShiftSchedule> AddShiftScheduleAsync(ShiftSchedule shiftSchedule);
        Task<ShiftSchedule> GetShiftScheduleByIdAsync(int id);
        Task<IEnumerable<ShiftSchedule>> GetAllShiftSchedulesAsync();
        Task<ShiftSchedule> UpdateShiftScheduleAsync(ShiftSchedule shiftSchedule);
        Task<bool> DeleteShiftScheduleAsync(int id);
    }
}
