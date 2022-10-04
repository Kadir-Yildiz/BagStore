using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CheckoutViewModel
    {
        public BasketViewModel Basket { get; set; }
        [Required, MaxLength(180)]
        public string? Street { get; set; }
        [Required, MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(60)]
        public string? State { get; set; }
        [Required, MaxLength(90)]
        public string? Country { get; set; }
        [Required, MaxLength(18)]
        public string? ZipCode { get; set; }
        [Required]
        public string? CCHolder { get; set; }
        [Required, CreditCard]
        public string? CCNumber { get; set; }
        [Required, RegularExpression(@"^[0-9]{2}\/[0-9]{2}$")]
        public string? CCExpiration{ get; set; }
        [Required, RegularExpression("^[0-9]{3}$")]
        public string? CCCvv { get; set; }
    }
}
