using Rs.App.Core.ClientRegistration.Domain;
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
        public bool IsActive { get; set; } = true;
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
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmaPassword { get; set; }

        protected Address Address()
        {
            return new Address {
                Country = Country,
                Line1 = Line1,
                Line2 = Line2,
                Line3 = Line3,
                Postcode = Postcode,
                Suburb = Suburb,
                CompareConcatenated = "",
            };
        }

        protected ClientCredential ClientCredential()
        {
            return new ClientCredential {
                Username = EmailAddress,
                Password = Password
            };
        }

        public Client Client()
        {
            return new Client
            {
                Address = Address(),
                ClientCredential = ClientCredential(),
                Dob = Dob,
                FirstName = FirstName,
                IsActive = IsActive,
                LastName = LastName,
                PhoneNumber = PhoneNumber
            };
        }
    }

    public static class ClientExtension
    {
        public static ClientViewModel CreateVm(this Client client)
        {
            return new ClientViewModel {                
                Country = client.Address.Country,
                Dob = client.Dob,
                EmailAddress = client.ClientCredential.Username,
                FirstName = client.FirstName,
                IsActive = client.IsActive,
                LastName = client.LastName,
                Line1 = client.Address.Line1,
                Line2 = client.Address.Line2,
                Line3 = client.Address.Line3,
                PhoneNumber = client.PhoneNumber,
                Postcode = client.Address.Postcode,
                Suburb = client.Address.Suburb
            };
        }
    }
}
