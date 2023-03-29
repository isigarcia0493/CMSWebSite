using CMSWebsite.Areas.Admin.ViewModels;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ICategoryService _categoryService;
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;
        private readonly IFormMessageService _formMessageService;

        public DashboardController(IAlbumService albumService, ICategoryService categoryService, 
                                   IEventService eventService, IImageService imageService, IFormMessageService formMessageService)
        {
            _albumService = albumService;
            _categoryService = categoryService;
            _eventService = eventService;
            _imageService = imageService;
            _formMessageService = formMessageService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            DashboardViewModel dashboardVM = new DashboardViewModel()
            {
                Album = _albumService.GetAllAlbums().ToList(),
                Category = _categoryService.GetAllCategories().ToList(),
                Event = _eventService.GetAllEvents().ToList(),
                Image = _imageService.GetAllImages().ToList(),
                Message = _formMessageService.GetAllMessages().ToList()
            };

            return View(dashboardVM);
        }

        public IActionResult PageNotFound()
        {
            return View("PageNotFound");
        }
    }
}
