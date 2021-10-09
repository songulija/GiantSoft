using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    /// <summary>
    /// CreateBrandDTO object. have one required field which is BrandName
    /// it has to be not longer than 45 letters. I can specify error message if its violated
    /// </summary>
    public class CreateBrandDTO
    {
        [Required]
        [StringLength(maximumLength: 45, MinimumLength = 1, ErrorMessage = "Brand Name Is Too Long")]
        public string BrandName { get; set; }
    }
    /// <summary>
    /// UpdateBrandDTO inherits from CreateBrandDTO. All its fields
    /// added IList of ProductDTO objects. so we can update Brand but also insert new Products
    /// </summary>
    public class UpdateBrandDTO : CreateBrandDTO
    {
        public virtual IList<ProductDTO> Products { get; set; }
    }
    /// <summary>
    /// BrandDTO inherits all fields from CreateBrandDTO
    /// and i added extra fields. So when getting data we will get Id too
    /// </summary>
    public class BrandDTO : CreateBrandDTO
    {
        public int Id { get; set; }
        public virtual IList<ProductDTO> Products { get; set; }
    }
}
