using TimeRecordingMicroservice.Dto;
using TimeRecordingMicroservice.Modellayer;

namespace TimeRecordingMicroservice.DtoConverter
{
    public static class TimeRegistrationsConverter
    {
        public static TimeRegistrationDto ToDto(TimeRegistration entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var totalWorkHours = (entity.CheckOutTime - entity.CheckInTime).TotalHours;
            var overtimeHours = totalWorkHours > 8 ? totalWorkHours - 8 : 0; // Antager over 8 timer som overarbejde

            return new TimeRegistrationDto
            {
                TimeRegistrationId = entity.TimeRegistrationId,
                Username = entity.Username,
                CheckInTime = entity.CheckInTime,
                CheckOutTime = entity.CheckOutTime,
                TotalWorkHours = totalWorkHours,
                OvertimeHours = overtimeHours,
            };
        }

        public static TimeRegistration ToEntity(TimeRegistrationDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            // Siden TotalWorkHours og OvertimeHours er beregnede værdier, fokuserer vi her kun på feltene, der skal sættes
            return new TimeRegistration
            {
                TimeRegistrationId = dto.TimeRegistrationId,
                Username = dto.Username,
                CheckInTime = dto.CheckInTime,
                CheckOutTime = dto.CheckOutTime,
                // Omit TotalWorkHours and OvertimeHours since they are calculated fields
            };
        }
    }
}

