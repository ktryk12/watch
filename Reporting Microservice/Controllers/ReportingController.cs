using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reporting_Microservice.Dto;
using Reporting_Microservice.Serviceslag;
using System.Threading.Tasks;

namespace Reporting_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportingController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _reportingService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{reportId}")]
        [Authorize]
        public async Task<IActionResult> GetReportById(int reportId)
        {
            var report = await _reportingService.GetReportByIdAsync(reportId);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReport([FromBody] ReportingDto reportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _reportingService.CreateReportAsync(reportDto);
            return CreatedAtAction(nameof(GetReportById), new { reportId = reportDto.ReportId }, reportDto);
        }

        [HttpPut("{reportId}")]
        [Authorize]
        public async Task<IActionResult> UpdateReport(int reportId, [FromBody] ReportingDto reportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _reportingService.UpdateReportAsync(reportId, reportDto);
            return NoContent();
        }

        [HttpDelete("{reportId}")]
        [Authorize]
        public async Task<IActionResult> DeleteReport(int reportId)
        {
            await _reportingService.DeleteReportAsync(reportId);
            return NoContent();
        }
    }
}

