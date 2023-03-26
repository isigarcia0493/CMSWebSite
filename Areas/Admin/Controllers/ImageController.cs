using CMSWebsite.Areas.Admin.ViewModels;
using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using CMSWebsite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IAlbumService _albumService;

        public ImageController(IImageService imageService, IAlbumService albumService)
        {
            _imageService = imageService;
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Image> images = _imageService.GetAllImages().ToList();

            foreach (var image in images)
            {
                image.Album = _albumService.GetAlbumById(image.AlbumId);
            }

            return View(images);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            ViewBag.Albums = _albumService.GetAllAlbums().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.AlbumId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(ImageViewModel iViewModel)
        {
            if (ModelState.IsValid)
            {
                iViewModel.UploadDate = DateTime.Now;

                var result = await _imageService.AddImageAsync(iViewModel.ImageUrl);

                var image = new Image
                {
                    Name = iViewModel.Name,
                    ShortDescription = iViewModel.ShortDescription,
                    LongDescription = iViewModel.LongDescription,
                    UploadDate = iViewModel.UploadDate,
                    ImageUrl = result.Url.ToString(),
                    PublicId = result.PublicId.ToString(),
                    AlbumId = iViewModel.AlbumId
                };

                _imageService.AddImage(image);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Upload Failed");
            }
            
            ViewBag.Albums = _albumService.GetAllAlbums().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.AlbumId.ToString()
            }).ToList();

            return View(iViewModel);
        }

        [HttpGet]
        public IActionResult ImageDetails(int id)
        {
            var image = _imageService.GetImageById(id);

            if (image == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                image.Album = _albumService.GetAlbumById(image.AlbumId);
                return View(image);
            }
        }

        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var image = _imageService.GetImageById(id);

            if (image == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                image.Album = _albumService.GetAlbumById(image.AlbumId);

                ImageViewModel iViewModel = new ImageViewModel
                {
                    ImageId = image.ImageId,
                    Name = image.Name,
                    ShortDescription = image.ShortDescription,
                    LongDescription = image.LongDescription,
                    AlbumId = image.Album.AlbumId,   
                    PublicId = image.PublicId,
                    UploadDate = image.UploadDate
                };

                ViewBag.albums = _albumService.GetAllAlbums().Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.AlbumId.ToString()
                }).ToList();

                return View(iViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditImageAsync(ImageViewModel iViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _imageService.AddImageAsync(iViewModel.ImageUrl);

                var image = _imageService.GetImageById(iViewModel.ImageId);
                await _imageService.DeleteImageAsync(image.PublicId);

                image.ImageId = iViewModel.ImageId;
                image.Name = iViewModel.Name;
                image.ShortDescription = iViewModel.ShortDescription;
                image.LongDescription = iViewModel.LongDescription;
                image.UploadDate = image.UploadDate;
                image.UpdatedDate = DateTime.Now;
                image.ImageUrl = result.Url.ToString();
                image.PublicId = result.PublicId.ToString();
                image.AlbumId = iViewModel.AlbumId;

                _imageService.EditImage(image);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Albums = _albumService.GetAllAlbums().Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.AlbumId.ToString()
                }).ToList();

                return View(iViewModel);
            }                                   
        }

        [HttpGet]
        public IActionResult DeleteImage(int id)
        {
            var image = _imageService.GetImageById(id);

            if (image == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                image.Album = _albumService.GetAlbumById(image.AlbumId);
                return View(image);
            }
        }

        [HttpPost]
        public IActionResult DeleteImage(Image model)
        {
            var image = _imageService.GetImageById(model.ImageId);

            _imageService.DeleteImageAsync(image.PublicId);
            _imageService.DeleteImage(image.ImageId);

            return RedirectToAction("Index");
        }
    }
}

