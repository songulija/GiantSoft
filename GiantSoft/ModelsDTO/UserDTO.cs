using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    //LoginDTO is for login. Then we need only Email and password
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
    /// <summary>
    /// UserDTO has to have same fields as ApiUser. It also inherits from LoginDTO
    /// Also user can have Roles(user or admin)
    /// </summary>
    public class UserDTO : LoginUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }
        public virtual IList<ProductDTO> Products { get; set; }
        public virtual IList<FeedbackDTO> Feedbacks { get; set; }
        public virtual IList<WhishlistDTO> Whishlists { get; set; }
        public virtual IList<JournalDTO> Journals { get; set; }
    }
}
