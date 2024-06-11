using System.ComponentModel.DataAnnotations;

namespace KickSharing.DataAccess.Models.Base
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}
