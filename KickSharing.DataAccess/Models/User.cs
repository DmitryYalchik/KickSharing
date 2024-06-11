using System.ComponentModel.DataAnnotations;
using KickSharing.DataAccess.DTOs.User;
using KickSharing.DataAccess.Models.Base;

namespace KickSharing.DataAccess.Models
{
    public class User : BaseModel
    {
        [MinLength(5, ErrorMessage = "Name must contain at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Name must contain no more than 50 characters")]
        public string Name { get; set; }

        [EmailAddress]
        [MinLength(5, ErrorMessage = "Email must contain at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Email must contain no more than 50 characters")]
        public string? Email { get; set; }
        public bool? IsEmailVerified { get; set; }

        [Phone]
        [MinLength(5, ErrorMessage = "Phone must contain at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Phone must contain no more than 50 characters")]
        public string? Phone { get; set; }
        public bool? IsPhoneVerified { get; set; }

        public Role Role { get; set; } = Role.User;

        public DateTime DateBirth { get; set; }

        public bool IsBlocked { get; set; } = false;

        public virtual ICollection<Rent>? Rents { get; set; }



        public User() { }
        public User(RegisterUser registerUser)
        {
            this.Name = registerUser.Name;
            this.Phone = registerUser.Phone;
            this.DateBirth = registerUser.DateBirth;
        }

        public void Update(UpdateUser updateUser)
        {
            this.Name = updateUser.Name;
            this.Email = updateUser.Email;
            this.Phone = updateUser.Phone;
            this.DateBirth = updateUser.DateBirth;

            if (this.Email != updateUser.Email)
                this.IsEmailVerified = false;
            if (this.Phone != updateUser.Phone)
                this.IsPhoneVerified = false;
        }
    }
}
