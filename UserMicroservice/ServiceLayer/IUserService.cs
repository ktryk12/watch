using UserMicroservice.Dto;

namespace UserMicroservice.ServiceLayer
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(NewUserDto newUserDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
        Task<bool> CheckIfPasswordShouldChangeAsync(int userId);

    }
}
