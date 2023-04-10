using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using CMSWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;

        public AlbumController(IAlbumService albumService, IImageService imageService, ICategoryService categoryService)
        {
            _albumService = albumService;
            _imageService = imageService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int? id)
        {
            if(id == null)
            {
                AlbumCategoryViewModel albums = new AlbumCategoryViewModel()
                {
                    AlbumList = _albumService.GetAllAlbums().ToList(),
                    CategoryList = _categoryService.GetAllCategories().ToList(),
                };

                ViewBag.CategoryName = "All Albums";
                return View(albums);
            }
            else
            {
                AlbumCategoryViewModel albums = new AlbumCategoryViewModel()
                {
                    AlbumList = _albumService.GetAllAlbums().Where(c => c.CategoryId == id).ToList(),
                    CategoryList = _categoryService.GetAllCategories().ToList(),
                };

                var category = _categoryService.GetCategoryById((int)id);

                ViewBag.CategoryName = category.CategoryName;

                return View(albums);
            }

        }

        [HttpGet]
        public IActionResult Photos(int id)
        {
            var album = _albumService.GetAlbumById(id);

            var images = _imageService.GetAllImages().Where(i => i.AlbumId == album.AlbumId);
            ViewBag.Album = album.Name;

            return View(images);
        }

        [HttpGet]
        public IActionResult OpenPhoto(int id)
        {
            var photo = _imageService.GetImageById(id);

            return View(photo);
        }
    }
}
