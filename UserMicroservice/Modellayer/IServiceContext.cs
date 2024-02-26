using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UserMicroservice.ModelLayer
{
    public interface IServiceContext
    {
        DbSet<User> Users { get; set; }
    }
}
