using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Notification_Microservice.Modellayer

{
    public interface IServiceContext
    {
        DbSet<Notification> Notification { get; set; }
    }
}
