using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// DatabaseContext inherits from IdentityDbContext and i'm adding
    /// ApiUser as its context. basically DbContext relative to ApiUser becouse
    /// by default it gonna use identity user
    /// </summary>
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        /**
        * Create a constructor. With DbContextOptions 
        * these options can be used to configure DataContext
        * And be use base class constructor. When using ApplicationDbContext class
        * we will have to provide those options to this constructor 
        * then it'll go to constructor of ApplicationDbContext class
        */
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        //With DbSets we define tables in our database. we can get and set smth to those tables
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Whishlist> Whishlists { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
