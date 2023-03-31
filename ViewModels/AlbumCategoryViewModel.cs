using CMSWebsite.Models;
using System.Collections.Generic;

namespace CMSWebsite.ViewModels
{
    public class AlbumCategoryViewModel
    {
        public List<Album> AlbumList { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
