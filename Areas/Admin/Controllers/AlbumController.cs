using CMSWebsite.Areas.Admin.ViewModels;
using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using CMSWebsite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;

        public AlbumController(IAlbumService albumService, ICategoryService categoryService, IImageService imageService)
        {
            _albumService = albumService;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        [HttpGet]
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
        public async Task<IActionResult> AddAlbumAsync(AlbumViewModel albumVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _imageService.AddImageAsync(albumVM.AlbumImageUrl);

                var album = new Album()
                {
                    Name = albumVM.Name,
                    ShortDescription = albumVM.ShortDescription,
                    LongDescription = albumVM.LongDescription,
                    PublicId = result.PublicId.ToString(),
                    AlbumImageUrl = result.Url.ToString(),
                    CategoryId = albumVM.CategoryId,
                };

                _albumService.AddAlbum(album);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _categoryService.GetAllCategories().Select(c => new SelectListItem()
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList();

                return View(albumVM);
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

                AlbumViewModel albumVM = new AlbumViewModel()
                {
                    AlbumId = album.AlbumId,
                    Name = album.Name,
                    ShortDescription = album.ShortDescription,
                    LongDescription = album.LongDescription,
                    CategoryId = album.CategoryId,
                };

                return View(albumVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAlbumAsync(AlbumViewModel albumVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _imageService.AddImageAsync(albumVM.AlbumImageUrl);

                var album = _albumService.GetAlbumById(albumVM.AlbumId);
                await _imageService.DeleteImageAsync(album.PublicId);

                album.AlbumId = albumVM.AlbumId;
                album.Name = albumVM.Name;
                album.ShortDescription = album.ShortDescription;
                album.LongDescription = albumVM.LongDescription;
                album.AlbumImageUrl = result.Url.ToString();
                album.PublicId = result.PublicId.ToString();
                album.CategoryId = albumVM.CategoryId;

                _albumService.EditAlbum(album);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _categoryService.GetAllCategories().Select(c => new SelectListItem()
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList();

                return View(albumVM);
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

            var album = _albumService.GetAlbumById(model.AlbumId);

            _imageService.DeleteImageAsync(album.PublicId);
            _albumService.DeleteAlbum(model.AlbumId);

            return RedirectToAction("Index");
        }
    }
}
