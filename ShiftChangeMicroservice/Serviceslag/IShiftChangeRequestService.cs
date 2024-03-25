using ShiftChangeMicroservice.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftChangeMicroservice.Serviceslag
{
    public interface IShiftChangeRequestService
    {
        Task<IEnumerable<ShiftChangeRequestDto>> GetAllShiftChangeRequestsAsync();
        Task<ShiftChangeRequestDto> GetShiftChangeRequestByIdAsync(int id);
        Task<IEnumerable<ShiftChangeRequestDto>> GetShiftChangeRequestByEmployeeIdAsync(string employeeId);
        Task<ShiftChangeRequestDto> CreateShiftChangeRequestAsync(CreateShiftChangeRequestDto createShiftChangeRequestDto);
        Task<ShiftChangeRequestDto> UpdateShiftChangeRequestAsync(int id, ShiftChangeRequestDto shiftChangeRequestDto);
        Task<bool> DeleteShiftChangeRequestAsync(int id);
    }
}
