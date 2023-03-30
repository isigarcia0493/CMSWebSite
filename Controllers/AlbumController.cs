using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
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

        public AlbumController(IAlbumService albumService, IImageService imageService)
        {
            _albumService = albumService;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            IEnumerable<Album> albums = _albumService.GetAllAlbums().ToList();

            return View(albums);
        }

        public IActionResult Photos(int id)
        {
            var album = _albumService.GetAlbumById(id);

            var images = _imageService.GetAllImages().Where(i => i.AlbumId == album.AlbumId);
            ViewBag.Album = album.Name;

            return View(images);
        }
    }
}
