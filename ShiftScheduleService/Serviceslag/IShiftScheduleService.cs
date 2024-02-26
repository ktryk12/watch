using ShiftScheduleMicroService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftScheduleMicroService.Serviceslag
{
    public interface IShiftScheduleService
    {
        Task<ShiftScheduleDto> AddShiftScheduleAsync(ShiftScheduleDto shiftScheduleDto);
        Task<ShiftScheduleDto> GetShiftScheduleByIdAsync(int id);
        Task<IEnumerable<ShiftScheduleDto>> GetAllShiftSchedulesAsync();
        Task<ShiftScheduleDto> UpdateShiftScheduleAsync(ShiftScheduleDto shiftScheduleDto);
        Task<bool> DeleteShiftScheduleAsync(int id);
    }
}
