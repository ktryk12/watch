using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccessibleMicroservicee.Modellayer
{
    public interface IServiceContext
    {
        DbSet<Availability> Availability { get; set; }
    }
}
