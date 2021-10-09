using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// Comment represents comments table in database.
    /// It has two foreignKeys : ProductId and UserId.
    /// Bellow have to define model Foreign key comes from[
    /// use NotMapped so it will not affect database
    /// </summary>
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        [ForeignKey(nameof(ApiUser))]
        public int UserId { get; set; }
        [NotMapped]
        public ApiUser ApiUser { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public float Rating { get; set; }
    }
}
