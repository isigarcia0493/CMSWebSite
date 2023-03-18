using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using CMSWebsite.Services;
using CMSWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ICategoryService _categoryService;

        public AlbumController(IAlbumService albumService, ICategoryService categoryService)
        {
            _albumService = albumService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {

            List<Album> albums = _albumService.GetAllAlbums().ToList();

            return View(albums);
        }

        [HttpGet]
        public IActionResult AddAlbum()
        {
            ViewBag.Categories = _categoryService.GetAllCategories().Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAlbum(Album model)
        {
            if (ModelState.IsValid)
            {
                _albumService.AddAlbum(model);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _categoryService.GetAllCategories().Select(c => new SelectListItem()
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList();

                return View(model);
            }
        }
    }
}
