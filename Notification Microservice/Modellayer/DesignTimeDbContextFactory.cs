using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Notification_Microservice.Modellayer
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=NotificationService;User Id=sa;Password=Sommer2023;TrustServerCertificate=true;");

            return new ServiceContext(optionsBuilder.Options, null);
        }

    }
}
