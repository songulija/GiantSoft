using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// This class ApiUser inherits from IdentityUser. All its fields
    /// like email, passwordHash and so on. virtual IList is basically saying
    /// that it has one to many relationships with Products table and ...
    /// </summary>
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<Feedback> Feedbacks { get; set; }
        public virtual IList<Whishlist> Whishlists { get; set; }
        public virtual IList<Journal> Journals { get; set; }
        public virtual IList<Comment> Comments { get; set; }

    }
}
