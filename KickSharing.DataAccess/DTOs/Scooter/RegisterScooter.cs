namespace KickSharing.DataAccess.DTOs.Scooter
{
    public class RegisterScooter
    {
        public required string Identifier { get; set; }
        public required int ChargePercent { get; set; }
    }
}