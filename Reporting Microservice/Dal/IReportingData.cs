using Reporting_Microservice.Modellayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reporting_Microservice.Dal
{
    public interface IReportingData
    {
        Task<IEnumerable<Reporting>> GetAllReportsAsync();
        Task<Reporting> GetReportByIdAsync(int reportId);
        Task<IEnumerable<Reporting>> GetReportingByEmployeeIdAsync(string employeeId);
        Task<Reporting> AddReportAsync(Reporting report);
        Task UpdateReportAsync(Reporting report);
        Task DeleteReportAsync(int reportId);
    }
}
