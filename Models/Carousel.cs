using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMSWebsite.Models
{
    public class Carousel
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

        [Required(ErrorMessage = "An image is required")]        
        [DisplayName("Upload Image")]
        public string ImageUrl { get; set; }

        [DisplayName("Is Employee Active?")]
        public bool DisplayImage { get; set; }
    }
}
