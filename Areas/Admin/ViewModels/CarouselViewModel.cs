using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Microsoft.AspNetCore.Http;

namespace CMSWebsite.Areas.Admin.ViewModels
{
    public class CarouselViewModel
    {
        [Key]
        public int CarouselId { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        [MaxLength(50)]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Enter a short description")]
        [MaxLength(100)]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Enter a long description")]
        [MaxLength(500)]
        [DisplayName("Long Descripiton")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Enter an expiration date")]
        [DisplayName("Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public string PublicId { get; set; }

        [DisplayName("Upload Image")]
        public IFormFile ImageUrl { get; set; }

        [DisplayName("Image for Display?")]
        public bool DisplayImage { get; set; }
    }
}
