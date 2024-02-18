using Microsoft.AspNetCore.Mvc;
using TimeRecordingMicroservice.Dto;
using TimeRecordingMicroservice.Serviceslag;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TimeRecordingMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TimeRegistrationController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeRegistrationController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TimeRegistrationDto>> AddTimeRegistration([FromBody] TimeRegistrationDto dto)
        {
            var addedTimeRegistration = await _timeService.AddTimeRegistrationAsync(dto);
            return CreatedAtAction(nameof(GetTimeRegistrationById), new { id = addedTimeRegistration.TimeRegistrationId }, addedTimeRegistration);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TimeRegistrationDto>> GetTimeRegistrationById(int id)
        {
            var timeRegistration = await _timeService.GetTimeRegistrationByIdAsync(id);
            if (timeRegistration == null)
            {
                return NotFound();
            }
            return Ok(timeRegistration);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TimeRegistrationDto>>> GetAllTimeRegistrations()
        {
            var timeRegistrations = await _timeService.GetAllTimeRegistrationsAsync();
            return Ok(timeRegistrations);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<TimeRegistrationDto>> UpdateTimeRegistration(int id, [FromBody] TimeRegistrationDto dto)
        {
            if (id != dto.TimeRegistrationId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedTimeRegistration = await _timeService.UpdateTimeRegistrationAsync(dto);
            return Ok(updatedTimeRegistration);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTimeRegistration(int id)
        {
            var success = await _timeService.DeleteTimeRegistrationAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
