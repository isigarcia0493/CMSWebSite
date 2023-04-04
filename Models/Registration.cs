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
