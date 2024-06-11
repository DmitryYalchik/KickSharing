using System.ComponentModel.DataAnnotations;
using KickSharing.DataAccess.DTOs.Scooter;
using KickSharing.DataAccess.Models.Base;

namespace KickSharing.DataAccess.Models
{
    public class Scooter : BaseModel
    {
        [MinLength(2, ErrorMessage = "Identifier must contain at least 2 characters")]
        [MaxLength(10, ErrorMessage = "Iidentifier must contain no more than 10 characters")]
        public string Identifier { get; set; }

        public int ChargePercent { get; set; }

        public bool IsBlocked { get; set; } = false;

        public virtual ICollection<Rent>? Rents { get; set; }



        public Scooter() { }

        public Scooter(RegisterScooter registerScooter)
        {
            this.Identifier = registerScooter.Identifier;
            this.ChargePercent = registerScooter.ChargePercent;
        }

        public void Update(UpdateScooter updateScooter)
        {
            this.Identifier = updateScooter.Identifier;
            this.ChargePercent = updateScooter.ChargePercent;
            this.IsBlocked = updateScooter.IsBlocked;
        }
    }
}
