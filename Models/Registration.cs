using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSWebsite.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }
        
        [Required(ErrorMessage = "Please enter your first name")]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName{ get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Please state how meny people will attend")]
        [DisplayName("People Attending")]
        public int PeopleAttending { get; set; }

        [DisplayName("Does require accomodations?")]
        public bool Accomodations { get; set; }

        [DisplayName("Please Describe the Accomodations")]
        public string DescribeAccomodations { get; set; }

        public ICollection<EventRegistration> EventRegistrations { get; set; }
        public ICollection<Event> Events { get; set; }


        //Relationships
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
