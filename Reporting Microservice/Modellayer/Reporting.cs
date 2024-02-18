using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reporting_Microservice.Modellayer
{
           public class Reporting
           {


            [Key]
            public int ReportId { get; set; }

            [Required]
            public string Period { get; set; }

            [Required]
            public string Type { get; set; } 

            [Required]
            [StringLength(4, MinimumLength = 4)]
            public string EmployeeId { get; set; }
    }
}
