using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
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
           
            foreach(var album in albums)
            {
                album.Category = _categoryService.GetCategoryById(album.CategoryId);
            }

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

        [HttpGet]
        public IActionResult AlbumDetails(int id)
        {
            var album = _albumService.GetAlbumById(id);

            if (album == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                album.Category = _categoryService.GetCategoryById(album.CategoryId);
                return View(album);
            }
        }

        [HttpGet]
        public IActionResult EditAlbum(int id)
        {
            var album = _albumService.GetAlbumById(id);

            if(album == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                album.Category = _categoryService.GetCategoryById(album.CategoryId);

                ViewBag.Categories = _categoryService.GetAllCategories().Select(c => new SelectListItem()
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList();

                return View(album);
            }
        }

        [HttpPost]
        public IActionResult EditAlbum(Album model)
        {
            if (ModelState.IsValid)
            {
                _albumService.EditAlbum(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult DeleteAlbum(int id)
        {
            var album = _albumService.GetAlbumById(id);

            if (album == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                album.Category = _categoryService.GetCategoryById(album.CategoryId);
                return View(album);
            }
        }

        [HttpPost]
        public IActionResult DeleteAlbum(Album model)
        {
            _albumService.DeleteAlbum(model.AlbumId);

            return RedirectToAction("Index");
        }
    }
}
