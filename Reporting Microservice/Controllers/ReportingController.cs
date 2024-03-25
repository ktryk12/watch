using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reporting_Microservice.Dto;
using Reporting_Microservice.Serviceslag;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reporting_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Sikrer, at alle endpoints kræver autentifikation.
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportingController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpGet]
        // Ingen specifik rolle nødvendig - både Admin og Medarbejder kan tilgå.
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _reportingService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{reportId}")]
        // Ingen specifik rolle nødvendig - både Admin og Medarbejder kan tilgå.
        public async Task<IActionResult> GetReportById(int reportId)
        {
            var report = await _reportingService.GetReportByIdAsync(reportId);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetReportsByEmployeeId(string employeeId)
        {
            // Tjekker brugerens rolle og ID
            var userClaims = User.Identity as ClaimsIdentity;
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = userClaims.FindFirst(ClaimTypes.Role)?.Value;

            // Sikrer, at en medarbejder kun kan anmode om sine egne rapporter
            if (userRole != "Admin" && userId != employeeId)
            {
                return Forbid(); // Returnerer en HTTP 403 Forbidden, hvis brugeren ikke har tilladelse
            }

            var reports = await _reportingService.GetReportsByEmployeeIdAsync(employeeId);

            if (reports == null || !reports.Any())
            {
                return NotFound("Ingen rapporter fundet.");
            }

            return Ok(reports);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Kun Admin kan oprette rapporter
        public async Task<IActionResult> CreateReport([FromBody] CreateReportingDto createReportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reportId = await _reportingService.CreateReportAsync(createReportDto);
            return CreatedAtAction(nameof(GetReportById), new { reportId = reportId }, new { reportId = reportId });
        }


        [HttpPut("{reportId}")]
        [Authorize(Roles = "Admin")] // Kun Admin kan opdatere rapporter.
        public async Task<IActionResult> UpdateReport(int reportId, [FromBody] ReportingDto reportDto)
        {
            if (!ModelState.IsValid || reportId != reportDto.ReportId)
            {
                return BadRequest(ModelState);
            }
            await _reportingService.UpdateReportAsync(reportId, reportDto);
            return NoContent();
        }

        [HttpDelete("{reportId}")]
        [Authorize(Roles = "Admin")] // Kun Admin kan slette rapporter.
        public async Task<IActionResult> DeleteReport(int reportId)
        {
            await _reportingService.DeleteReportAsync(reportId);
            return NoContent();
        }
    }
}
