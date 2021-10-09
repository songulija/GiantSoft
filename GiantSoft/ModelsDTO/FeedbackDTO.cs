using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    public class CreateFeedbackDTO
    {
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [StringLength(maximumLength: 150, MinimumLength = 1, ErrorMessage = "Feedbacm Text Must Be Between 1 to 150 letters")]
        public string FeedbackText { get; set; }
        [Required]
        [Range(0.5, 5, ErrorMessage = "Rating Must Be Between 0.5 and 5")]
        public double Rating { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
    public class UpdateFeedbackDTO : CreateFeedbackDTO
    {
    }
    /// <summary>
    /// Inherit all fields from CreateFeedbackDTO. When getting record 
    /// we'll get Id and if included can get ApiUser object
    /// </summary>
    public class FeedbackDTO : CreateFeedbackDTO
    {
        public int Id { get; set; }
        public UserDTO ApiUser { get; set; }
    }
}
