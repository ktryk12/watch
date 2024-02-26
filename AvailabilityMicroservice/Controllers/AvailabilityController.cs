using Microsoft.AspNetCore.Mvc;
using AvailabilityMicroservice.Serviceslag;
using AvailabilityMicroservice.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace AvailabilityMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _availabilityService;

        public AvailabilityController(IAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAvailability([FromBody] AvailabilityDto dto)
        {
            var createdAvailability = await _availabilityService.CreateAvailabilityAsync(dto);
            return CreatedAtAction(nameof(GetAvailabilityById), new { employeeId = createdAvailability.EmployeeId, availableDate = createdAvailability.AvailableDate }, createdAvailability);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AvailabilityDto>>> GetAllAvailabilities()
        {
            var availabilities = await _availabilityService.GetAllAvailabilitiesAsync();
            return Ok(availabilities);
        }

        [HttpGet("{employeeId}/{availableDate}")]
        [Authorize]
        public async Task<ActionResult<AvailabilityDto>> GetAvailabilityById(string employeeId, DateTime availableDate)
        {
            var availability = await _availabilityService.GetAvailabilityByIdAsync(employeeId, availableDate);
            if (availability == null)
            {
                return NotFound();
            }
            return Ok(availability);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAvailability([FromBody] AvailabilityDto dto)
        {
            await _availabilityService.UpdateAvailabilityAsync(dto);
            return NoContent();
        }

        [HttpDelete("{employeeId}/{availableDate}")]
        [Authorize]
        public async Task<IActionResult> DeleteAvailability(string employeeId, DateTime availableDate)
        {
            await _availabilityService.DeleteAvailabilityAsync(employeeId, availableDate);
            return NoContent();
        }
    }
}
