using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMSWebsite.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [DisplayName("Category Name")]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Short Description is required")]
        [DisplayName("Short Description")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Long Description is required")]
        [DisplayName("Long Description")]
        [MaxLength(500)]
        public string LongDescription { get; set; }

        public IEnumerable<Album> Album { get; set; }
    }
}
