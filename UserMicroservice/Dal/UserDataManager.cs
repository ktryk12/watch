using Microsoft.EntityFrameworkCore;
using UserMicroservice.ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace UserMicroservice.Dal
{
    public class UserDataManager: IUserData
    {
        private readonly ServiceContext _context;

        public UserDataManager(ServiceContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByEmployeeIdAsync(string employeeId)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }

} 