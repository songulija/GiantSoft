using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// Journal has userId and productId foreign keys
    /// journals table saves if item was SEEN, ADDED TO WHISHLIST
    /// Thats a Type
    /// </summary>
    public class Journal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(ApiUser))]
        public int UserId { get; set; }
        [NotMapped]
        public ApiUser ApiUser { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

    }
}
