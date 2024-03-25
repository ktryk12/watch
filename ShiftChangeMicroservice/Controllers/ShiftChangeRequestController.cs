using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShiftChangeMicroservice.Dto;
using ShiftChangeMicroservice.Serviceslag;
using System.Threading.Tasks;

namespace ShiftChangeMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Sikrer generel autorisering for adgang til controlleren.
    public class ShiftChangeRequestController : ControllerBase
    {
        private readonly IShiftChangeRequestService _shiftChangeRequestService;

        public ShiftChangeRequestController(IShiftChangeRequestService shiftChangeRequestService)
        {
            _shiftChangeRequestService = shiftChangeRequestService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")] // Tilpas rollerne efter behov.
        public async Task<IActionResult> GetAllShiftChangeRequests()
        {
            var shiftChangeRequests = await _shiftChangeRequestService.GetAllShiftChangeRequestsAsync();
            return Ok(shiftChangeRequests);
        }

        [HttpGet("{id}")]
        [Authorize] // Sikrer at kun autoriserede roller kan tilgå individuelle anmodninger.
        public async Task<IActionResult> GetShiftChangeRequestById(int id)
        {
            var shiftChangeRequest = await _shiftChangeRequestService.GetShiftChangeRequestByIdAsync(id);
            if (shiftChangeRequest == null)
            {
                return NotFound();
            }
            return Ok(shiftChangeRequest);
        }

        [HttpGet("employee/{employeeId}")]
        [Authorize] // Giver adgang for ansatte til at se deres egne anmodninger.
        public async Task<IActionResult> GetShiftChangeRequestsByEmployeeId(string employeeId)
        {
            var shiftChangeRequests = await _shiftChangeRequestService.GetShiftChangeRequestByEmployeeIdAsync(employeeId);
            return Ok(shiftChangeRequests);
        }

        [HttpPost]
        [Authorize(Roles = "Medarbejder")] // Antager at kun medarbejdere kan oprette skiftændringsanmodninger.
        public async Task<IActionResult> CreateShiftChangeRequest([FromBody] CreateShiftChangeRequestDto createShiftChangeRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdShiftChangeRequest = await _shiftChangeRequestService.CreateShiftChangeRequestAsync(createShiftChangeRequestDto);
            return CreatedAtAction(nameof(GetShiftChangeRequestById), new { id = createdShiftChangeRequest.Id }, createdShiftChangeRequest);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Antager at kun admin og manager kan opdatere anmodninger.
        public async Task<IActionResult> UpdateShiftChangeRequest(int id, [FromBody] ShiftChangeRequestDto shiftChangeRequestDto)
        {
            if (!ModelState.IsValid || id != shiftChangeRequestDto.Id)
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
        [Authorize(Roles = "Admin")] // Antager at kun admin og manager har rettigheder til at slette anmodninger.
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
