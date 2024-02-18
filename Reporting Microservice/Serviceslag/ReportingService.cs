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

        public async Task CreateReportAsync(ReportingDto reportDto) // Opdateret til CreateReportAsync
        {
            var report = ReportingConverter.FromDtoForCreation(reportDto);
            await _reportingData.AddReportAsync(report); // Bemærk: Her kalder vi stadig AddReportAsync på dataadgangslaget
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
