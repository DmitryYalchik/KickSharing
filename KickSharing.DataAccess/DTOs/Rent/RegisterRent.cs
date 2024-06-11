namespace KickSharing.DataAccess.DTOs.Rent
{
    public class RegisterRent
    {
        public required string UserId { get; set; }
        public required string ScooterId { get; set; }
        public required string StartLatitude { get; set; }
        public required string StartLongitude { get; set; }
    }
}
