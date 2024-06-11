using KickSharing.DataAccess.Models.Base;

namespace KickSharing.DataAccess.Models
{
    public class Price : BaseModel
    {
        public double MinutePrice { get; set; }
        public virtual ICollection<Rent>? Rents { get; set; }



        public Price() { }
        public Price(double minutePrice)
        {
            this.MinutePrice = minutePrice;
        }
    }
}
