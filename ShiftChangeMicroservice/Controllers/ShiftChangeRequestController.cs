using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShiftChangeMicroservice.Dto;
using ShiftChangeMicroservice.Serviceslag;
using System.Threading.Tasks;

namespace ShiftChangeMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShiftChangeRequestController : ControllerBase
    {
        private readonly IShiftChangeRequestService _shiftChangeRequestService;

        public ShiftChangeRequestController(IShiftChangeRequestService shiftChangeRequestService)
        {
            _shiftChangeRequestService = shiftChangeRequestService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllShiftChangeRequests()
        {
            var shiftChangeRequests = await _shiftChangeRequestService.GetAllShiftChangeRequestsAsync();
            return Ok(shiftChangeRequests);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetShiftChangeRequestById(int id)
        {
            var shiftChangeRequest = await _shiftChangeRequestService.GetShiftChangeRequestByIdAsync(id);
            if (shiftChangeRequest == null)
            {
                return NotFound();
            }
            return Ok(shiftChangeRequest);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateShiftChangeRequest([FromBody] ShiftChangeRequestDto shiftChangeRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdShiftChangeRequest = await _shiftChangeRequestService.CreateShiftChangeRequestAsync(shiftChangeRequestDto);
            return CreatedAtAction(nameof(GetShiftChangeRequestById), new { id = createdShiftChangeRequest.Id }, createdShiftChangeRequest);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateShiftChangeRequest(int id, [FromBody] ShiftChangeRequestDto shiftChangeRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedShiftChangeRequest = await _shiftChangeRequestService.UpdateShiftChangeRequestAsync(id, shiftChangeRequestDto);
            if (updatedShiftChangeRequest == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteShiftChangeRequest(int id)
        {
            var result = await _shiftChangeRequestService.DeleteShiftChangeRequestAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
