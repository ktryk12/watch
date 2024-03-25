using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Reporting_Microservice.Modellayer
{
    public class ServiceContext : DbContext, IServiceContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public ServiceContext(DbContextOptions<ServiceContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Reporting> Reporting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(_loggerFactory)
                    .UseSqlServer("Server=localhost;Database=ReportingService;Integrated Security=True;TrustServerCertificate=true;"); // Tilføj din databaseforbindelsesstreng
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurer dine modeller her, hvis nødvendigt
        }
    }
}
