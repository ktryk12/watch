using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UserMicroservice.Modellayer
{
    public class ServiceContext : DbContext, IServiceContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public ServiceContext(DbContextOptions<ServiceContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(_loggerFactory)
                    .UseSqlServer("Server=localhost;Database=UserService;User Id=sa;Password=Sommer2023;TrustServerCertificate=true;"); // Tilføj din databaseforbindelsesstreng
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurer dine modeller her, hvis nødvendigt
        }
    }
}
