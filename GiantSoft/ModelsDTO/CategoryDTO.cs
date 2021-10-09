using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    /// <summary>
    /// This object will have fealds that are neccessary for
    /// Category creation. Set required fields. ParentId is not required. By default it will be null
    /// </summary>
    public class CreateCategoryDTO
    {
        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2, ErrorMessage = "Category Name length Should Be 2-40 letters")]
        public string Name { get; set; }
        public int? ParentId { get; set; }

    }
    /// <summary>
    /// UpdateCategoryDTO inherits from CreateCategoryDTO. All its fields
    /// added IList of ProductDTO objects. so we can update Brand but also insert new Products
    /// </summary>
    public class UpdateCategoryDTO : CreateCategoryDTO
    {
        public virtual IList<ProductDTO> Products { get; set; }
    }
    /// <summary>
    /// This object will have all fealds of CreateCategoryDTO and CategoryDTO.
    /// So when getting you get Id and all other fields. When getting if we include
    /// i can get list of products associated with Category
    /// </summary>
    public class CategoryDTO : CreateCategoryDTO
    {
        public int Id { get; set; }
        public virtual IList<ProductDTO> Products { get; set; }
    }
}
