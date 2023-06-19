using CMSWebsite.Areas.Admin.ViewModels;
using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using CMSWebsite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        private readonly IWebHostEnvironment _hostEnvironment;

        public AlbumController(IAlbumService albumService, ICategoryService categoryService, IImageService imageService, IWebHostEnvironment hostEnvironment)
        {
            _albumService = albumService;
            _categoryService = categoryService;
            _imageService = imageService;
            _hostEnvironment = hostEnvironment;
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
            ViewBag.Categories = GetCategories();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAlbumAsync(AlbumViewModel albumVM)
        {
            if (ModelState.IsValid)
            {
                Album album = new Album();

                string rootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(albumVM.AlbumImageUrl.FileName);
                string extension = Path.GetExtension(albumVM.AlbumImageUrl.FileName);
                album.AlbumImageUrl = fileName = fileName + extension;
                string path = Path.Combine(rootPath + "/Images/Albums/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await albumVM.AlbumImageUrl.CopyToAsync(fileStream);
                }

                album.Name = albumVM.Name;
                album.ShortDescription = albumVM.ShortDescription;
                album.LongDescription = albumVM.LongDescription;
                album.CategoryId = albumVM.CategoryId;

                _albumService.AddAlbum(album);

                return RedirectToAction("Index");               
            }
            else
            {
                ViewBag.Categories = GetCategories();

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

                ViewBag.Categories = GetCategories();

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

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _categoryService.GetAllCategories().Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> EditAlbumAsync(AlbumViewModel albumVM)
        {
            if (ModelState.IsValid)
            {
                var album = _albumService.GetAlbumById(albumVM.AlbumId);

                if (albumVM.AlbumImageUrl != null)
                {
                    var result = await _imageService.AddImageAsync(albumVM.AlbumImageUrl);

                    if (result.Error == null)
                    {
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
                        TempData["Error"] = result.Error.Message.ToString();
                        ViewBag.Categories = GetCategories();

                        return View(albumVM);
                    }    
                }
                else
                {
                    album = _albumService.GetAlbumById(albumVM.AlbumId);

                    album.AlbumId = albumVM.AlbumId;
                    album.Name = albumVM.Name;
                    album.ShortDescription = album.ShortDescription;
                    album.LongDescription = albumVM.LongDescription;
                    album.CategoryId = albumVM.CategoryId;

                    _albumService.EditAlbum(album);

                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                ViewBag.Categories = GetCategories();

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
            var imgaePath = Path.Combine(_hostEnvironment.WebRootPath + "/Images/Albums/", album.AlbumImageUrl);

            if(System.IO.File.Exists(imgaePath))
            {
                System.IO.File.Delete(imgaePath);
            }

            _albumService.DeleteAlbum(model.AlbumId);

            return RedirectToAction("Index");
        }
    }
}
