using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShiftScheduleMicroService.Dto;
using ShiftScheduleMicroService.Serviceslag;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftScheduleMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftScheduleController : ControllerBase
    {
        private readonly IShiftScheduleService _shiftScheduleService;

        public ShiftScheduleController(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ShiftScheduleDto>> AddShiftSchedule([FromBody] CreateShiftScheduleDto createShiftScheduleDto)
        {
            var employeeId = User.Claims.FirstOrDefault(c => c.Type == "EmployeeId")?.Value;

            var createdShiftSchedule = await _shiftScheduleService.AddShiftScheduleAsync(createShiftScheduleDto);

            if (createdShiftSchedule == null)
            {
                return BadRequest("Unable to add shift schedule");
            }

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

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ShiftScheduleDto>>> GetAllShiftSchedules()
        {
            var schedules = await _shiftScheduleService.GetAllShiftSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("employee/{employeeId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ShiftScheduleDto>>> GetShiftSchedulesByEmployeeId(string employeeId)
        {
            var schedules = await _shiftScheduleService.GetShiftSchedulesByEmployeeIdAsync(employeeId);
            return Ok(schedules);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ShiftScheduleDto>> UpdateShiftSchedule(int id, [FromBody] ShiftScheduleDto shiftScheduleDto)
        {
            if (id != shiftScheduleDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                var updatedShiftSchedule = await _shiftScheduleService.UpdateShiftScheduleAsync(shiftScheduleDto);
                return Ok(updatedShiftSchedule);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteShiftSchedule(int id)
        {
            try
            {
                var success = await _shiftScheduleService.DeleteShiftScheduleAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
