using ShiftChangeMicroservice.Dal;
using ShiftChangeMicroservice.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShiftChangeMicroservice.DtoConverter;

namespace ShiftChangeMicroservice.Serviceslag
{
    public class ShiftChangeRequestService : IShiftChangeRequestService
    {
        private readonly IShiftChangeData _shiftChangeData;

        public ShiftChangeRequestService(IShiftChangeData shiftChangeData)
        {
            _shiftChangeData = shiftChangeData;
        }

        public async Task<IEnumerable<ShiftChangeRequestDto>> GetAllShiftChangeRequestsAsync()
        {
            var shiftChangeRequests = await _shiftChangeData.GetAllShiftChangeRequestsAsync();
            return shiftChangeRequests.Select(ShiftChangeRequestConverter.ToDto);
        }

        public async Task<ShiftChangeRequestDto> GetShiftChangeRequestByIdAsync(int id)
        {
            var shiftChangeRequest = await _shiftChangeData.GetShiftChangeRequestByIdAsync(id);
            return shiftChangeRequest != null ? ShiftChangeRequestConverter.ToDto(shiftChangeRequest) : null;
        }

        public async Task<ShiftChangeRequestDto> CreateShiftChangeRequestAsync(ShiftChangeRequestDto shiftChangeRequestDto)
        {
            var shiftChangeRequest = ShiftChangeRequestConverter.ToEntityForCreation(shiftChangeRequestDto);
            var createdShiftChangeRequest = await _shiftChangeData.AddShiftChangeRequestAsync(shiftChangeRequest);
            return ShiftChangeRequestConverter.ToDto(createdShiftChangeRequest);
        }

        public async Task<ShiftChangeRequestDto> UpdateShiftChangeRequestAsync(int id, ShiftChangeRequestDto shiftChangeRequestDto)
        {
            var shiftChangeRequest = ShiftChangeRequestConverter.ToEntity(shiftChangeRequestDto);
            shiftChangeRequest.Id = id; // Ensure the ID is correctly assigned for the update
            var updatedShiftChangeRequest = await _shiftChangeData.UpdateShiftChangeRequestAsync(shiftChangeRequest);
            return ShiftChangeRequestConverter.ToDto(updatedShiftChangeRequest);
        }

        public async Task<bool> DeleteShiftChangeRequestAsync(int id)
        {
            return await _shiftChangeData.DeleteShiftChangeRequestAsync(id);
        }
    }
}
