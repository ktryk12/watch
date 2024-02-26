using Microsoft.EntityFrameworkCore;
using ShiftChangeMicroservice.Modellayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftChangeMicroservice.Dal
{
    public class ShiftChangeDataManager : IShiftChangeData
    {
        private readonly ServiceContext _context;

        public ShiftChangeDataManager(ServiceContext context)
        {
            _context = context;
        }

        public async Task<ShiftChangeRequest> AddShiftChangeRequestAsync(ShiftChangeRequest shiftChangeRequest)
        {
            _context.ShiftChangeRequest.Add(shiftChangeRequest);
            await _context.SaveChangesAsync();
            return shiftChangeRequest;
        }

        public async Task<ShiftChangeRequest> GetShiftChangeRequestByIdAsync(int id)
        {
            return await _context.ShiftChangeRequest.FindAsync(id);
        }

        public async Task<IEnumerable<ShiftChangeRequest>> GetAllShiftChangeRequestsAsync()
        {
            return await _context.ShiftChangeRequest.ToListAsync();
        }

        public async Task<ShiftChangeRequest> UpdateShiftChangeRequestAsync(ShiftChangeRequest shiftChangeRequest)
        {
            var request = await _context.ShiftChangeRequest.FindAsync(shiftChangeRequest.Id);
            if (request != null)
            {
                _context.Entry(request).CurrentValues.SetValues(shiftChangeRequest);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<bool> DeleteShiftChangeRequestAsync(int id)
        {
            var request = await _context.ShiftChangeRequest.FindAsync(id);
            if (request != null)
            {
                _context.ShiftChangeRequest.Remove(request);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
