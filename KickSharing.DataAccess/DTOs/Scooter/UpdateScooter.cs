﻿namespace KickSharing.DataAccess.DTOs.Scooter
{
    public class UpdateScooter
    {
        public required string Identifier { get; set; }
        public required int ChargePercent { get; set; }
        public required bool IsBlocked { get; set; }
    }
}