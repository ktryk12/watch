using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ShiftChangeMicroservice.Modellayer
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {     
        public ServiceContext CreateDbContext(string[] args)
        {
                var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
                optionsBuilder.UseSqlServer("Server=localhost;Database=ShiftChangeService;Integrated Security=True;TrustServerCertificate=true;");

                return new ServiceContext(optionsBuilder.Options, null);
        }
        
    }
}
