using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// Product have many to one relationships with Categories &
    /// Brands. And One-To-Many relationships with Images and Stocks
    /// It has One-To-Many relationships with Journal & Whishlist
    /// If its included you can get list of Images,Stocks,Whishlists, Journals. we dont need to include this into migration
    /// so we use VIRTUAL
    /// </summary>
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(ApiUser))]
        public int? UserId { get; set; }
        [NotMapped]
        public ApiUser ApiUser { get; set; }
        [ForeignKey(nameof(Brand))]
        public int? BrandId { get; set; }
        [NotMapped]
        public Brand Brand { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [NotMapped]
        public Category Category { get; set; }
        public string ProductName { get; set; }
        public DateTime ModelYear { get; set; }
        public double Price { get; set; }
        public int CountInStock { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public String OtherBrand { get; set; }
        public string ImageString { get; set; }
        //Products have many to one connection with Brands

        public virtual IList<Whishlist> Whishlists { get; set; }
        public virtual IList<Journal> Journals { get; set; }
        public virtual IList<Payment> Payments { get; set; }
    }
}
