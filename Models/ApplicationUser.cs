using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace CMSWebsite.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        [StringLength(100)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(100)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your State")]
        [StringLength(50)]
        [DisplayName("State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your zip code")]
        [DisplayName("First Name")]
        public int ZipCode { get; set; }
    }
}
