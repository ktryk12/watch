using UserMicroservice.Dto;
using UserMicroservice.ModelLayer;

namespace UserMicroservice.DtoConverter
{
    public class UserDtoConverter
    {
        public static UserDto ToDto(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Name = entity.Name,
                Email = entity.Email,
                Role = entity.Role
                
            };
        }

        public static User ToEntity(UserDto dto)
        {
            return new User
            {
                Id= dto.Id,
                EmployeeId = dto.EmployeeId,
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role
            };
        }

        // Tilføjet: Specifik metode til at håndtere oprettelse fra DTO uden ID
        public static User ToEntityForCreation(NewUserDto dto)
        {
            return new User
            {
                EmployeeId = dto.EmployeeId,
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role
                // PasswordHash skal håndteres separat, da det ofte involverer kryptering og validering
            };
        }
    }
}
