using ShiftChangeMicroservice.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftChangeMicroservice.Serviceslag
{
    public interface IShiftChangeRequestService
    {
        Task<IEnumerable<ShiftChangeRequestDto>> GetAllShiftChangeRequestsAsync();
        Task<ShiftChangeRequestDto> GetShiftChangeRequestByIdAsync(int id);
        Task<ShiftChangeRequestDto> CreateShiftChangeRequestAsync(ShiftChangeRequestDto shiftChangeRequestDto);
        Task<ShiftChangeRequestDto> UpdateShiftChangeRequestAsync(int id, ShiftChangeRequestDto shiftChangeRequestDto);
        Task<bool> DeleteShiftChangeRequestAsync(int id);
    }
}
