using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Reporting_Microservice.Modellayer

{
    public interface IServiceContext
    {
        DbSet<Reporting> Reporting { get; set; }
    }
}
