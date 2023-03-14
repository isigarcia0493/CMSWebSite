using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSWebsite.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Image Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short description is required")]
        [DisplayName("Short Description")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Long description is required")]
        [DisplayName("Long Description")]
        [MaxLength(500)]
        public string LongDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }


        // Relationship
        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public Album Album { get; set; }
    }
}
