using UserMicroservice.ModelLayer;
using UserMicroservice.Dto;
using UserMicroservice.Dal;
using UserMicroservice.DtoConverter;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroservice.SecurityServices;

namespace UserMicroservice.ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;
        private readonly PasswordService _passwordService;

        public UserService(IUserData userData, PasswordService passwordService)
        {
            _userData = userData;
            _passwordService = passwordService;
        }

        public async Task<UserDto> CreateUserAsync(NewUserDto newUserDto)
        {
            var user = UserDtoConverter.ToEntityForCreation(newUserDto);

            // Antag at PasswordService er en dependency i UserService
            var passwordService = new PasswordService();
            passwordService.CreatePasswordHash(newUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordLastChanged = DateTime.UtcNow; // Sæt PasswordLastChanged til nuværende tidspunkt

            var createdUser = await _userData.CreateAsync(user);

            // Konverterer den oprettede bruger tilbage til en DTO
            return UserDtoConverter.ToDto(createdUser);
        }

        public async Task<bool> CheckIfPasswordShouldChangeAsync(int userId)
        {
            var user = await _userData.GetByIdAsync(userId);
            if (user != null)
            {
                return (DateTime.UtcNow - user.PasswordLastChanged).TotalDays >= 90;
            }
            return false;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userData.GetAllAsync();
            var userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                userDtos.Add(UserDtoConverter.ToDto(user));
            }
            return userDtos;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userData.GetByIdAsync(id);
            return user != null ? UserDtoConverter.ToDto(user) : null;
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = UserDtoConverter.ToEntity(userDto);
            await _userData.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userData.DeleteAsync(id);
        }
    }

}
