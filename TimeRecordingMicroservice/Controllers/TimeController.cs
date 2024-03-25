using Microsoft.AspNetCore.Mvc;
using TimeRecordingMicroservice.Dto;
using TimeRecordingMicroservice.Serviceslag;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TimeRecordingMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Dette sikrer, at alle endpoints kræver autentifikation generelt.
    public class TimeRegistrationController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeRegistrationController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        // Tillad kun Admin at tilføje nye tidsregistreringer
        [HttpPost]
        [Authorize(Roles = "Admin,Medarbejder")]
        public async Task<ActionResult<TimeRegistrationDto>> AddTimeRegistration([FromBody] TimeRegistrationDto dto)
        {
            var addedTimeRegistration = await _timeService.AddTimeRegistrationAsync(dto);
            return CreatedAtAction(nameof(GetTimeRegistrationById), new { id = addedTimeRegistration.TimeRegistrationId }, addedTimeRegistration);
        }

        // Tillad både Admin og Medarbejder at se en specifik tidsregistrering
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Medarbejder")]
        public async Task<ActionResult<TimeRegistrationDto>> GetTimeRegistrationById(int id)
        {
            var timeRegistration = await _timeService.GetTimeRegistrationByIdAsync(id);
            if (timeRegistration == null)
            {
                return NotFound();
            }
            return Ok(timeRegistration);
        }

        // Tillad både Admin og Medarbejder at se alle tidsregistreringer
        [HttpGet]
        [Authorize(Roles = "Admin,Medarbejder")]
        public async Task<ActionResult<IEnumerable<TimeRegistrationDto>>> GetAllTimeRegistrations()
        {
            var timeRegistrations = await _timeService.GetAllTimeRegistrationsAsync();
            return Ok(timeRegistrations);
        }

        // Tillad kun Admin at opdatere tidsregistreringer
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TimeRegistrationDto>> UpdateTimeRegistration(int id, [FromBody] TimeRegistrationDto dto)
        {
            if (id != dto.TimeRegistrationId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedTimeRegistration = await _timeService.UpdateTimeRegistrationAsync(dto);
            return Ok(updatedTimeRegistration);
        }

        // Tillad kun Admin at slette tidsregistreringer
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTimeRegistration(int id)
        {
            var success = await _timeService.DeleteTimeRegistrationAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("employee/{employeeId}")]
        [Authorize(Roles = "Admin,Medarbejder")] // Sikrer, at kun autoriserede roller kan tilgå endpointet.
        public async Task<ActionResult<IEnumerable<TimeRegistrationDto>>> GetTimeRegistrationsByEmployeeId(string employeeId)
        {
            // Tjekker, om den aktuelt autentificerede bruger har rettigheder til at se data for den angivne ansat.
            // Dette kan indebære at sammenligne employeeId med den autentificerede brugers ID eller tjekke for en Admin-rolle.
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (employeeId != currentUserId && currentUserRole != "Admin")
            {
                return Forbid(); // Eller returner en passende fejlkode.
            }

            var timeRegistrations = await _timeService.GetTimeRegistrationsByEmployeeIdAsync(employeeId);
            if (timeRegistrations == null || !timeRegistrations.Any())
            {
                return NotFound();
            }

            return Ok(timeRegistrations);
        }

    }
}
