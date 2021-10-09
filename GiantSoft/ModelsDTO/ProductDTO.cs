using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    public class CreateProductDTO
    {
        public int? BrandId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 1, ErrorMessage = "Product Name Should Be Betweem 1 to 60 Characters")]
        public string ProductName { get; set; }
        public DateTime ModelYear { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CountInStock { get; set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Description Should Be Between 5 to 100 Characters")]
        public string Description { get; set; }
        public string Color { get; set; }
        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 1, ErrorMessage = "Country Name Should Be Between 1 to 60 Characters")]
        public string Country { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Country Name Should Be Between 1 to 50 Characters")]
        public string City { get; set; }
        [Required]
        public DateTime AddDate { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        public string OtherBrand { get; set; }
        public virtual IList<ImageDTO> Images { get; set; }
    }
    /// <summary>
    /// UpdateProductDTO inherits from CreateProductDTO. All its fields
    /// added IList of Images objects. so we can update Product but also insert new Images
    /// </summary>
    public class UpdateProductDTO : CreateProductDTO
    {
    }
    /// <summary>
    /// Inherits fields from CreateProductDTO. When getting can get Id,
    /// Brand, Category objects associated with it if they are included.
    /// </summary>
    public class ProductDTO : CreateProductDTO
    {
        public int Id { get; set; }
        public UserDTO ApiUser { get; set; }
        public BrandDTO Brand { get; set; }
        public CategoryDTO Category { get; set; }
        public virtual IList<WhishlistDTO> Whishlists { get; set; }
        public virtual IList<JournalDTO> Journals { get; set; }
        public virtual IList<PaymentDTO> Payments { get; set; }
    }
}
