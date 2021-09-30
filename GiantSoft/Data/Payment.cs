using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// Payment class will have fields as status,updatetime,emailadress
    /// that will come from paypal, when you make payment. ForeignKey is productId
    /// </summary>
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string UpdateTime { get; set; }
        public string EmailAdress { get; set; }
    }
}
