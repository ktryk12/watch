using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace TimeRecordingMicroservice.Modellayer
{ 
    public interface IServiceContext
    {
        DbSet<TimeRegistration> TimeRegistration { get; set; }
    }
}
