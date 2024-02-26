using AvailabilityMicroservice.Dto;
using AvailabilityMicroservice.Modellayer;

namespace AvailabilityMicroservice.DtoConverter
{
    public class AvailabilityConverter
    {
        public static AvailabilityDto ToDto(Availability entity)
        {
            return new AvailabilityDto
            {
                EmployeeId = entity.EmployeeId,
                AvailableDate = entity.AvailableDate,
                AvailableTime = entity.AvailableTime
            };
        }
        public static Availability ToEntity(AvailabilityDto dto)
        {
            return new Availability
            {
                EmployeeId = dto.EmployeeId,
                AvailableDate = dto.AvailableDate,
                AvailableTime = dto.AvailableTime
            };
        }
    }
}
