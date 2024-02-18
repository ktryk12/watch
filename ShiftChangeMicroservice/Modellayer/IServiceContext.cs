using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ShiftChangeMicroservice.Modellayer
{
    public interface IServiceContext
    {
        DbSet<ShiftChangeRequest> ShiftChangeRequest { get; set; }
    }
}
