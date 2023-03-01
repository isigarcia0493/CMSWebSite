using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMSWebsite.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short description is required")]
        [DisplayName("Short Decription")]
        [StringLength(50)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Long description is required")]
        [DisplayName("Name")]
        [StringLength(500)]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [DisplayName("Category")]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
