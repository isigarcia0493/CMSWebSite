using CMSWebsite.Models;
using System.Collections.Generic;

namespace CMSWebsite.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Album> Album { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Event> Event { get; set; }
        public IEnumerable<Image> Image { get; set; }
        public IEnumerable<Registration> Registration { get; set; }
        public IEnumerable<FormMessage> Message { get; set; }
    }
}
