using System;
using System.ComponentModel.DataAnnotations;

namespace web_1.Models
{
    public class Odeme
    {

        [Key]
        public int OdemeId { get; set; }

        [Required(ErrorMessage = "Name on card is required.")]
        public string CardholderName { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        public string Expiration { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        public string CVV { get; set; }

     
    }
}
