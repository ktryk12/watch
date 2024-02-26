﻿using ShiftScheduleMicroService.Dal;
using ShiftScheduleMicroService.Dto;
using ShiftScheduleMicroService.DtoConverter;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ShiftScheduleMicroService.Serviceslag
{
    public class ShiftScheduleService : IShiftScheduleService
    {
        private readonly IShiftScheduleData _shiftScheduleData;

        public ShiftScheduleService(IShiftScheduleData shiftScheduleData)
        {
            _shiftScheduleData = shiftScheduleData;
        }

        public async Task<ShiftScheduleDto> AddShiftScheduleAsync(ShiftScheduleDto shiftScheduleDto)
        {
            var shiftSchedule = ShiftScheduleConverter.ToEntity(shiftScheduleDto);
            var addedShiftSchedule = await _shiftScheduleData.AddShiftScheduleAsync(shiftSchedule);
            return ShiftScheduleConverter.ToDto(addedShiftSchedule);
        }

        public async Task<ShiftScheduleDto> GetShiftScheduleByIdAsync(int id)
        {
            var shiftSchedule = await _shiftScheduleData.GetShiftScheduleByIdAsync(id);
            return ShiftScheduleConverter.ToDto(shiftSchedule);
        }

        public async Task<IEnumerable<ShiftScheduleDto>> GetAllShiftSchedulesAsync()
        {
            var shiftSchedules = await _shiftScheduleData.GetAllShiftSchedulesAsync();
            return shiftSchedules.Select(shiftSchedule => ShiftScheduleConverter.ToDto(shiftSchedule)).ToList();
        }

        public async Task<ShiftScheduleDto> UpdateShiftScheduleAsync(ShiftScheduleDto shiftScheduleDto)
        {
            var shiftSchedule = ShiftScheduleConverter.ToEntity(shiftScheduleDto);
            var updatedShiftSchedule = await _shiftScheduleData.UpdateShiftScheduleAsync(shiftSchedule);
            return ShiftScheduleConverter.ToDto(updatedShiftSchedule);
        }

        public async Task<bool> DeleteShiftScheduleAsync(int id)
        {
            return await _shiftScheduleData.DeleteShiftScheduleAsync(id);
        }
    }
}
