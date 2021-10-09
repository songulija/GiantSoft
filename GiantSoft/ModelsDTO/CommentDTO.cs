using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    public class CreateCommentDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Rating { get; set; }
    }

    public class UpdateCommentDTO : CreateCommentDTO
    {

    }

    public class CommentDTO : CreateCommentDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public UserDTO ApiUser { get; set; }

    }
}
