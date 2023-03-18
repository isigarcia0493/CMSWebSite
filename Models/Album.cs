using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSWebsite.Models
{
    public class Album
    {
        public Album()
        {
            List<Album> albums = new List<Album>();
        }

        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short description is required")]
        [DisplayName("Short Decription")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Long description is required")]
        [DisplayName("Name")]
        [MaxLength(500)]
        public string LongDescription { get; set; }

        public ICollection<Image> Images { get; set; }

        //Relationship
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
