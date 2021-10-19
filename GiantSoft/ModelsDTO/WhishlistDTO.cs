using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    /// <summary>
    /// When adding new record to Whishlists table i dont need Id,UserDTO fields
    /// Adding fields only neccessary for creation
    /// </summary>
    public class CreateWhishlistDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
    /// <summary>
    /// For record Update we need same fields as Creation. This class inherits
    /// all fields from CreateWhishlistDTO class
    /// </summary>
    public class UpdateWhishlistDTO : CreateWhishlistDTO
    {
    }
    /// <summary>
    /// When getting records from Whishlists table i want Id,
    /// if included UserDTO, ProductDTO details too. This class inherits
    /// from CreateWhishlistDTO
    /// </summary>
    public class WhishlistDTO : CreateWhishlistDTO
    {
        public int Id { get; set; }
        public UserDTO ApiUser { get; set; }
        public ProductDTO Product { get; set; }
    }
}
