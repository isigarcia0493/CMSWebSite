using CMSWebsite.Areas.Admin.ViewModels;
using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using CMSWebsite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;

        public EventController(IEventService eventService, IImageService imageService)
        {
            _eventService = eventService;
            _imageService = imageService;
        }


        public IActionResult Index()
        {
            List<Event> events = _eventService.GetAllEvents().ToList();

            //foreach (var eventModel in events)
            //{
            //    album.Category = _categoryService.GetCategoryById(album.CategoryId);
            //}

            return View(events);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(EventViewModel eventVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _imageService.AddImageAsync(eventVM.ImageUrl);

                var eventModel = new Event()
                {
                    EventName = eventVM.EventName,
                    ShortDescription = eventVM.ShortDescription,
                    LongDescription = eventVM.LongDescription,
                    StartDate = eventVM.StartDate,
                    EndDate = eventVM.EndDate,
                    StartTime = eventVM.StartTime,
                    EndTime = eventVM.EndTime,
                    Address = eventVM.Address,
                    City = eventVM.City,
                    State = eventVM.States.ToString(),
                    ZipCode = eventVM.ZipCode,
                    Email = eventVM.Email,
                    PhoneNumber = eventVM.PhoneNumber,
                    PublicId = result.PublicId.ToString(),
                    ImageUrl = result.Url.ToString()
                };

                _eventService.AddEvent(eventModel);

                return RedirectToAction("Index");
            }
            else
            {
                return View(eventVM);
            }
        }

        [HttpGet]
        public IActionResult EventDetails(int id)
        {
            var eventModel = _eventService.GetEventById(id);

            if (eventModel == null)
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
            else
            {
                return View(eventModel);
            }
        }
    }
}
