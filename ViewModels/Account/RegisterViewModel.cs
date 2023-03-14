using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMSWebsite.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "The confirmation password does not match the password")]
        public string PasswordConfirmation { get; set; }

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

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(14)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

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
