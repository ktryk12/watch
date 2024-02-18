using System;
using System.ComponentModel.DataAnnotations;

namespace TimeRecordingMicroservice.Modellayer
{
    public class TimeRegistration
    {
        [Key]
        public int TimeRegistrationId { get; set; }

        // Brugernavn, der refererer til en ansat
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string Username { get; set; }

        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        // Beregner det samlede antal arbejdstimer
        public double TotalWorkHours { get; set; }

        // Dette felt kan bruges til at gemme beregnet overarbejde
        public double OvertimeHours { get; set; }

        // Yderligere metoder og logikker efter behov
    }
}
