using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    /// <summary>
    /// To add Image to database we dont need Id and Product object fields
    /// </summary>
    public class CreateImageDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Picture { get; set; }
    }
    /// <summary>
    /// This class inherits all fields from CreateImageDTO
    /// </summary>
    public class UpdateImageDTO : CreateImageDTO
    {

    }
    /// <summary>
    /// When getting records from Images table. I want to get image id,
    /// and if included get product details. This class inherits all fields from CreateImageDTO class
    /// </summary>
    public class ImageDTO : CreateImageDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
    }
}
