using ShiftScheduleMicroService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftScheduleMicroService.Serviceslag
{
    public interface IShiftScheduleService
    {
        Task<ShiftScheduleDto> AddShiftScheduleAsync(CreateShiftScheduleDto createDto);
        Task<ShiftScheduleDto> GetShiftScheduleByIdAsync(int id);
        Task<IEnumerable<ShiftScheduleDto>> GetAllShiftSchedulesAsync();
        Task<IEnumerable<ShiftScheduleDto>> GetShiftSchedulesByEmployeeIdAsync(string employeeId);
        Task<ShiftScheduleDto> UpdateShiftScheduleAsync(ShiftScheduleDto shiftScheduleDto);
        Task<bool> DeleteShiftScheduleAsync(int id);
    }
}
