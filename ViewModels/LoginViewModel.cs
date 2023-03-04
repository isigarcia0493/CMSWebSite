using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMSWebsite.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your email!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}
