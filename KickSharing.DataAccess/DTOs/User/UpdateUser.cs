namespace KickSharing.DataAccess.DTOs.User
{
    public class UpdateUser
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required DateTime DateBirth { get; set; }
    }
}
