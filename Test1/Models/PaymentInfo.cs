using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class PaymentInfo
    {
        [Required(ErrorMessage = "Please enter your credit card number.")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Invalid credit card number.")]
        [Display(Name = "Credit Card Number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter the card's expiration month.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])$", ErrorMessage = "Invalid expiration month.")]
        [Display(Name = "Expiration Month")]
        public string ExpirationMonth { get; set; }

        [Required(ErrorMessage = "Please enter the card's expiration year.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid expiration year.")]
        [Display(Name = "Expiration Year")]
        public string ExpirationYear { get; set; }

        [Required(ErrorMessage = "Please enter the CVV/CVC code.")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid CVV/CVC code.")]
        [Display(Name = "CVV/CVC")]
        public string CVV { get; set; }
    }


}