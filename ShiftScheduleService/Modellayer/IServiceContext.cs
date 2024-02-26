using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ShiftScheduleMicroService.Modellayer
{
    public interface IServiceContext
    {
        DbSet<ShiftSchedule> ShiftSchedule { get; set; }
    }
}
