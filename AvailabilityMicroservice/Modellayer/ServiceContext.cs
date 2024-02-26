using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace AvailabilityMicroservice.Modellayer
{
    public class ServiceContext : DbContext, IServiceContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public ServiceContext(DbContextOptions<ServiceContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Availability> Availability { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(_loggerFactory)
                    .UseSqlServer("Server=localhost;Database=AvailabilityService;User Id=sa;Password=Sommer2023;TrustServerCertificate=true;"); // Tilføj din databaseforbindelsesstreng
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availability>()
    .HasKey(a => new { a.EmployeeId, a.AvailableDate, a.AvailableTime });

        }

    }
}
