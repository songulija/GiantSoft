using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// Feedback table will have to Foreign Keys
    /// from same table. ReceiverId and SenderId from ApiUsers table
    /// </summary>
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(ApiUser))]
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        [NotMapped]
        public ApiUser ApiUser { get; set; }
        public string FeedbackText { get; set; }
        public double Rating { get; set; }
        public DateTime Date { get; set; }
    }
}
