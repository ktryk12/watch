using ShiftChangeMicroservice.Modellayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftChangeMicroservice.Dal
{
    public interface IShiftChangeData
    {
        Task<ShiftChangeRequest> AddShiftChangeRequestAsync(ShiftChangeRequest shiftChangeRequest);
        Task<ShiftChangeRequest> GetShiftChangeRequestByIdAsync(int id);
        Task<IEnumerable<ShiftChangeRequest>> GetAllShiftChangeRequestsAsync();
        Task<ShiftChangeRequest> UpdateShiftChangeRequestAsync(ShiftChangeRequest shiftChangeRequest);
        Task<bool> DeleteShiftChangeRequestAsync(int id);
    }
}
