using Reporting_Microservice.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reporting_Microservice.Serviceslag
{
    public interface IReportingService
    {
        Task<IEnumerable<ReportingDto>> GetAllReportsAsync();
        Task<ReportingDto> GetReportByIdAsync(int reportId);
        Task<IEnumerable<ReportingDto>> GetReportsByEmployeeIdAsync(string employeeId);
        Task<int> CreateReportAsync(CreateReportingDto createReportDto);
        Task UpdateReportAsync(int reportId, ReportingDto reportDto);
        Task DeleteReportAsync(int reportId);
    }
}
