using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UserMicroservice.Modellayer
{
    public interface IServiceContext
    {
        DbSet<User> Users { get; set; }
    }
}
