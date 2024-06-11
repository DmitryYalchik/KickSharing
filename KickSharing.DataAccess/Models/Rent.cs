using KickSharing.DataAccess.DTOs.Rent;
using KickSharing.DataAccess.Models.Base;

namespace KickSharing.DataAccess.Models
{
    public class Rent : BaseModel
    {
        public string ScooterId { get; set; }
        public virtual Scooter? Scooter { get; set; }

        public string PriceId { get; set; }
        public virtual Price? Price { get; set; }

        public string UserId { get; set; }
        public virtual User? User { get; set; }

        public DateTime StartDateTime { get; set; } = DateTime.UtcNow;
        public string StartLatitude { get; set; }
        public string StartLongitude { get; set; }

        public DateTime? FinishDateTime { get; set; }
        public string? FinishLatitude { get; set; }
        public string? FinishLongitude { get; set; }



        public Rent() { }
        public Rent(RegisterRent registerRent, string priceId)
        {
            this.ScooterId = registerRent.ScooterId;
            this.UserId = registerRent.UserId;
            this.StartLatitude = registerRent.StartLatitude;
            this.StartLongitude = registerRent.StartLongitude;
            this.PriceId = priceId;
        }

        public void Finish(FinishRent finishRent)
        {
            this.FinishLatitude = finishRent.FinishLatitude;
            this.FinishLongitude = finishRent.FinishLongitude;
            this.FinishDateTime = DateTime.UtcNow;
        }
    }
}
