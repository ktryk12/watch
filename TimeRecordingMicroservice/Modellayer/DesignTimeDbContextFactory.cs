using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TimeRecordingMicroservice.Modellayer
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=TimeRecordingService;User Id=sa;Password=Sommer2023;TrustServerCertificate=true;");

            return new ServiceContext(optionsBuilder.Options, null);
        }

    }
}
