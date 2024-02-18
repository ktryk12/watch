using Microsoft.EntityFrameworkCore;
using Reporting_Microservice.Modellayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reporting_Microservice.Dal
{
    public class ReportingDataManager : IReportingData
    {
        private readonly ServiceContext _context;

        public ReportingDataManager(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reporting>> GetAllReportsAsync()
        {
            return await _context.Reporting.ToListAsync();
        }

        public async Task<Reporting> GetReportByIdAsync(int reportId)
        {
            return await _context.Reporting.FirstOrDefaultAsync(r => r.ReportId == reportId);
        }

        public async Task AddReportAsync(Reporting report)
        {
            await _context.Reporting.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Reporting report)
        {
            _context.Reporting.Update(report);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReportAsync(int reportId)
        {
            var report = await _context.Reporting.FindAsync(reportId);
            if (report != null)
            {
                _context.Reporting.Remove(report);
                await _context.SaveChangesAsync();
            }
        }
    }
}
