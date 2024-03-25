using Reporting_Microservice.Dal;
using Reporting_Microservice.Dto;
using Reporting_Microservice.DtoConverter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting_Microservice.Serviceslag
{
    public class ReportingService : IReportingService
    {
        private readonly IReportingData _reportingData;

        public ReportingService(IReportingData reportingData)
        {
            _reportingData = reportingData;
        }

        public async Task<IEnumerable<ReportingDto>> GetAllReportsAsync()
        {
            var reports = await _reportingData.GetAllReportsAsync();
            return reports.Select(ReportingConverter.ToDto);
        }

        public async Task<ReportingDto> GetReportByIdAsync(int reportId)
        {
            var report = await _reportingData.GetReportByIdAsync(reportId);
            return report != null ? ReportingConverter.ToDto(report) : null;
        }
        public async Task<IEnumerable<ReportingDto>> GetReportsByEmployeeIdAsync(string employeeId)
        {
            var Reportings = await _reportingData.GetReportingByEmployeeIdAsync(employeeId);
            return Reportings.Select(ReportingConverter.ToDto);
        }
        public async Task<int> CreateReportAsync(CreateReportingDto createReportDto)
        {
            var report = ReportingConverter.ToEntityForCreation(createReportDto);
            await _reportingData.AddReportAsync(report); // Efter denne linje, vil report.Id være sat.
            return report.ReportId; // Returner ID'et for den nyoprettede rapport.
        }


        public async Task UpdateReportAsync(int reportId, ReportingDto reportDto)
        {
            var report = ReportingConverter.FromDtoForUpdate(reportId, reportDto);
            await _reportingData.UpdateReportAsync(report);
        }

        public async Task DeleteReportAsync(int reportId)
        {
            await _reportingData.DeleteReportAsync(reportId);
        }
    }
}
