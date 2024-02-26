using AvailabilityMicroservice.Modellayer;
using AvailabilityMicroservice.Dto;
using AvailabilityMicroservice.Dal;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AvailabilityMicroservice.DtoConverter;

namespace AvailabilityMicroservice.Serviceslag
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityData _availabilityData;

        public AvailabilityService(IAvailabilityData availabilityData)
        {
            _availabilityData = availabilityData;
        }

        public async Task<AvailabilityDto> CreateAvailabilityAsync(AvailabilityDto dto)
        {
            var availability = AvailabilityConverter.ToEntity(dto);
            await _availabilityData.CreateAsync(availability);
            return AvailabilityConverter.ToDto(availability);
        }

        public async Task<IEnumerable<AvailabilityDto>> GetAllAvailabilitiesAsync()
        {
            var availabilities = await _availabilityData.GetAllAsync();
            var dtoList = new List<AvailabilityDto>();
            foreach (var availability in availabilities)
            {
                dtoList.Add(AvailabilityConverter.ToDto(availability));
            }
            return dtoList;
        }

        public async Task<AvailabilityDto> GetAvailabilityByIdAsync(string employeeId, DateTime availableDate)
        {
            var availability = await _availabilityData.GetByIdAsync(employeeId, availableDate);
            return availability != null ? AvailabilityConverter.ToDto(availability) : null;
        }

        public async Task UpdateAvailabilityAsync(AvailabilityDto dto)
        {
            var availability = AvailabilityConverter.ToEntity(dto);
            await _availabilityData.UpdateAsync(availability);
        }

        public async Task DeleteAvailabilityAsync(string employeeId, DateTime availableDate)
        {
            await _availabilityData.DeleteAsync(employeeId, availableDate);
        }
    }
}
