using ShiftChangeMicroservice.Modellayer;
using ShiftChangeMicroservice.Dto;

namespace ShiftChangeMicroservice.DtoConverter
{
    public static class ShiftChangeRequestConverter
    {
        public static ShiftChangeRequestDto ToDto(ShiftChangeRequest entity)
        {
            return new ShiftChangeRequestDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                DesiredShiftId = entity.DesiredShiftId,
                Reason = entity.Reason,
                Status = entity.Status
            };
        }

        // Eksisterende metode til konvertering fra DTO til entitet
        public static ShiftChangeRequest ToEntity(ShiftChangeRequestDto dto)
        {
            return new ShiftChangeRequest
            {
                Id = dto.Id, // Dette inkluderes for fuldstændighed, men vil normalt ikke bruges ved oprettelse
                EmployeeId = dto.EmployeeId,
                DesiredShiftId = dto.DesiredShiftId,
                Reason = dto.Reason,
                Status = dto.Status
            };
        }

        // Tilføjet: Specifik metode til at håndtere oprettelse fra DTO uden ID
        public static ShiftChangeRequest ToEntityForCreation(CreateShiftChangeRequestDto dto)
        {
            return new ShiftChangeRequest
            {
                // Id feltet er udeladt, så det kan genereres automatisk
                EmployeeId = dto.EmployeeId,
                DesiredShiftId = dto.DesiredShiftId,
                Reason = dto.Reason,
                Status = dto.Status
            };
        }
    }
}
