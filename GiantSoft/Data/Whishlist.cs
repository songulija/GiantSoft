using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// Whishlist table will have two Foreign Keys.
    /// UserId and ProductId. Also has date when record was added
    /// </summary>
    public class Whishlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(ApiUser))]
        public Guid UserId { get; set; }
        [NotMapped]
        public ApiUser ApiUser { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public DateTime Date { get; set; }

    }
}
