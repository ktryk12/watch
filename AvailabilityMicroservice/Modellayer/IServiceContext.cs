using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AvailabilityMicroservice.Modellayer
{
    public interface IServiceContext
    {
        DbSet<Availability> Availability { get; set; }
    }
}
