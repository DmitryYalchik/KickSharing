namespace KickSharing.DataAccess.DTOs.User
{
    public class RegisterUser
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required DateTime DateBirth { get; set; }
    }
}
