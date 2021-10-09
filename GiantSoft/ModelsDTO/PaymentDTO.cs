using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    public class CreatePaymentDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string UpdateTime { get; set; }
        [Required]
        public string EmailAdress { get; set; }
    }

    public class UpdatePaymentDTO : CreatePaymentDTO
    {

    }

    /// <summary>
    /// inherits all fields from CreatePaymentDTO. When getting payment if included
    /// get Product object too
    /// </summary>
    public class PaymentDTO : CreatePaymentDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
    }
}
