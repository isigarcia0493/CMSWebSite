using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebsite.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarouselService _carouselService;

        public HomeController(ILogger<HomeController> logger, ICarouselService carouselService)
        {
            _logger = logger;
            _carouselService = carouselService;
        }

        public IActionResult Index(bool viewBag)
        {
            IEnumerable<Carousel> imagesList = _carouselService.GetAllCarousel().Where(c => c.ExpirationDate >= DateTime.Now).ToList();

            return View(imagesList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NotFound404()
        {
            return View();
        }
    }
}
