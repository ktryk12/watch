using UserMicroservice.ModelLayer;

namespace UserMicroservice.Dal
{
    public interface IUserData
    {
        Task<User> CreateAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task DeleteAsync(int id);
    }
}
