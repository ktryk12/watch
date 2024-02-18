using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ShiftScheduleService.Modellayer
{
    public interface IServiceContext
    {
        DbSet<ShiftSchedule> ShiftSchedule { get; set; }
    }
}
