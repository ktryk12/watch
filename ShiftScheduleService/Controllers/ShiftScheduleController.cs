using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShiftScheduleMicroService.Dto;
using ShiftScheduleMicroService.Serviceslag;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftScheduleMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShiftScheduleController : ControllerBase
    {
        private readonly IShiftScheduleService _shiftScheduleService;

        public ShiftScheduleController(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ShiftScheduleDto>> AddShiftSchedule([FromBody] ShiftScheduleDto shiftScheduleDto)
        {
            var createdShiftSchedule = await _shiftScheduleService.AddShiftScheduleAsync(shiftScheduleDto);
            return CreatedAtAction(nameof(GetShiftScheduleById), new { id = createdShiftSchedule.Id }, createdShiftSchedule);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ShiftScheduleDto>> GetShiftScheduleById(int id)
        {
            var shiftSchedule = await _shiftScheduleService.GetShiftScheduleByIdAsync(id);
            if (shiftSchedule == null)
            {
                return NotFound();
            }
            return Ok(shiftSchedule);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ShiftScheduleDto>>> GetAllShiftSchedules()
        {
            var shiftSchedules = await _shiftScheduleService.GetAllShiftSchedulesAsync();
            return Ok(shiftSchedules);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ShiftScheduleDto>> UpdateShiftSchedule(int id, [FromBody] ShiftScheduleDto shiftScheduleDto)
        {
            if (id != shiftScheduleDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var updatedShiftSchedule = await _shiftScheduleService.UpdateShiftScheduleAsync(shiftScheduleDto);
            if (updatedShiftSchedule == null)
            {
                return NotFound();
            }
            return Ok(updatedShiftSchedule);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteShiftSchedule(int id)
        {
            var success = await _shiftScheduleService.DeleteShiftScheduleAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
