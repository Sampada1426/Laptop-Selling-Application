using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your shipping address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your postal code.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a shipping method.")]
        [Display(Name = "Shipping Method")]
        public string ShippingMethod { get; set; }

        [Required(ErrorMessage = "Please enter your credit card number.")]
        [Display(Name = "Credit Card Number")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Invalid credit card number.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter the card's expiration month.")]
        [Display(Name = "Expiration Month")]
        [RegularExpression(@"^(0[1-9]|1[0-2])$", ErrorMessage = "Invalid expiration month.")]
        public string ExpirationMonth { get; set; }

        [Required(ErrorMessage = "Please enter the card's expiration year.")]
        [Display(Name = "Expiration Year")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid expiration year.")]
        public string ExpirationYear { get; set; }

        [Required(ErrorMessage = "Please enter the CVV/CVC code.")]
        [Display(Name = "CVV/CVC")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid CVV/CVC code.")]
        public string CVV { get; set; }

    }

}