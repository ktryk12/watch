using System.ComponentModel.DataAnnotations;

namespace UserMicroservice.ModelLayer
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string EmployeeId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime PasswordLastChanged { get; set; }
        // Andre nødvendige egenskaber...
    }
}
