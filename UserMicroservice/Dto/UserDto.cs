namespace UserMicroservice.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string EmployeeId {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime PasswordLastChanged { get; set; }
    }
}
