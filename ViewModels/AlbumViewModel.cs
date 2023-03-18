using CMSWebsite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CMSWebsite.ViewModels
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public Category Category { get; set; }
    }
}
