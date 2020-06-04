using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Ng.ClientRegistration.ViewModel
{
    public class ClientViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(250)]
        [MinLength(1)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        // number with dash but not dash at the front
        [Required]
        [RegularExpression("^(?!-)[0-9\\-?]{8,15}$")] //https://regexr.com/
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [MaxLength(250)]
        public string Line1 { get; set; }
        [MaxLength(250)]
        public string Line2 { get; set; }
        [MaxLength(250)]
        public string Line3 { get; set; }
        [Required]
        [MaxLength(250)]
        public string Suburb { get; set; }
        [Required]
        [MaxLength(250)]
        public string Postcode { get; set; }
        [Required]
        [MaxLength(250)]
        public string Country { get; set; }
        [Required]
        [MaxLength(250)]
        public string Username { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmationPassword { get; set; }
    }
}
