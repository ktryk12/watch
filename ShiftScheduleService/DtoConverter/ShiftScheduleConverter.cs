using ShiftScheduleMicroService.Dto;
using ShiftScheduleMicroService.Modellayer;

namespace ShiftScheduleMicroService.DtoConverter
{
    public static class ShiftScheduleConverter
    {
        public static ShiftScheduleDto ToDto(ShiftSchedule entity)
        {
            return new ShiftScheduleDto
            {
                Id = entity.Id,
                Date = entity.Date,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                BreakTime = entity.BreakTime,
                EmployeeId = entity.EmployeeId,
                Status = entity.Status
            };
        }

        public static ShiftSchedule ToEntity(ShiftScheduleDto dto)
        {
            return new ShiftSchedule
            {
                Id = dto.Id,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                BreakTime = dto.BreakTime,
                EmployeeId = dto.EmployeeId,
                Status = dto.Status
            };
        }
        public static ShiftSchedule ToEntity(CreateShiftScheduleDto dto)
        {
            return new ShiftSchedule
            {
                // Ingen Id, da det genereres af databasen
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                BreakTime = dto.BreakTime,
                EmployeeId = dto.EmployeeId,
                Status = dto.Status
            };
        }

    }
}
