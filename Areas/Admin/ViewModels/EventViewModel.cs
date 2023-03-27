using CMSWebsite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Microsoft.AspNetCore.Http;
using CMSWebsite.Models.Enums;
using CMSWebsite.Helpers;

namespace CMSWebsite.Areas.Admin.ViewModels
{
    public class EventViewModel
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        [MaxLength(50)]
        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Enter short description")]
        [MaxLength(50)]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Enter long description")]
        [MaxLength(500)]
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Enter start date")]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Enter end date")]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Enter start time")]
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "Enter end time")]
        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }

        [Required(ErrorMessage = "Enter the event address")]
        [MaxLength(100)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter the city")]
        [MaxLength(100)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter the State")]
        [MaxLength(50)]
        [DisplayName("State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter zip code")]
        [MaxLength(5)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Enter email")]
        [MaxLength(50)]
        [DisplayName("Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the contact phone number")]
        [MaxLength(20)]
        [DisplayName("Contact Phone Number")]
        public string PhoneNumber { get; set; }

        public string PublicId { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [DisplayName("Upload Photo")]
        public IFormFile ImageUrl { get; set; }

        public ICollection<EventRegistration> EventRegistrations { get; set; }

        public States States { get; set; }
    }
}
