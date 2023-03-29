using CMSWebsite.Areas.Admin.ViewModels;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CMSWebsite.Models;
using System.Linq;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class CarouselController : Controller
    {
        private readonly ICarouselService _carouselService;
        private readonly IImageService _imageService;

        public CarouselController(ICarouselService carouselService, IImageService imageService)
        {
            _carouselService = carouselService;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Carousel> carousels = _carouselService.GetAllCarousel().ToList();

            return View(carousels);
        }

        [HttpGet]
        public IActionResult AddCarousel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCarousel(CarouselViewModel cViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _imageService.AddImageAsync(cViewModel.ImageUrl);

                if(result.Error == null)
                {
                    var carousel = new Carousel
                    {
                        ImageName = cViewModel.ImageName,
                        ShortDescription = cViewModel.ShortDescription,
                        LongDescription = cViewModel.LongDescription,
                        ExpirationDate = cViewModel.ExpirationDate,
                        PublicId = result.PublicId,
                        ImageUrl = result.Url.ToString(),
                    };

                    _carouselService.AddCarousel(carousel);

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result.Error.Message.ToString();
                    return View(cViewModel);
                }                
            }
            else
            {
                ModelState.AddModelError("", "Upload Failed");
            }

            return View(cViewModel);
        }

        [HttpGet]
        public IActionResult CarouselDetails(int id)
        {
            var carousel = _carouselService.GetCarouselById(id);

            if (carousel == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                return View(carousel);
            }
        }

        [HttpGet]
        public IActionResult EditCarousel(int id)
        {
            var carousel = _carouselService.GetCarouselById(id);

            if (carousel == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {             
                CarouselViewModel cViewModel = new CarouselViewModel
                {
                    CarouselId = carousel.CarouselId,
                    ImageName = carousel.ImageName,
                    ShortDescription = carousel.ShortDescription,
                    LongDescription = carousel.LongDescription,
                    ExpirationDate = carousel.ExpirationDate,
                    PublicId = carousel.PublicId,
                };

                return View(cViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCarousel(CarouselViewModel cViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _imageService.AddImageAsync(cViewModel.ImageUrl);
                var carousel = _carouselService.GetCarouselById(cViewModel.CarouselId);

                if(result.Error == null)
                {
                    await _imageService.DeleteImageAsync(carousel.PublicId);

                    carousel.ImageName = cViewModel.ImageName;
                    carousel.ShortDescription = cViewModel.ShortDescription;
                    carousel.LongDescription = cViewModel.LongDescription;
                    carousel.ExpirationDate = cViewModel.ExpirationDate;
                    carousel.PublicId = result.PublicId.ToString();
                    carousel.ImageUrl = result.Url.ToString();

                    _carouselService.EditCarousel(carousel);

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result.Error.Message.ToString();
                    return View(cViewModel);
                }
            }
            else
            {
                return View(cViewModel);
            }
        }

        [HttpGet]
        public IActionResult DeleteCarousel(int id)
        {
            var carousel = _carouselService.GetCarouselById(id);

            if (carousel == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                return View(carousel);
            }
        }

        [HttpPost]
        public IActionResult DeleteCarousel(Carousel model)
        {
            var carousel = _carouselService.GetCarouselById(model.CarouselId);

            _imageService.DeleteImageAsync(carousel.PublicId);
            _carouselService.DeleteCarousel(carousel.CarouselId);

            return RedirectToAction("Index");
        }
    }
}
