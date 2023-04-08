using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMSWebsite.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventSetvice;

        public EventController(IEventService eventSetvice)
        {
            _eventSetvice = eventSetvice;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var events = _eventSetvice.GetAllEvents().ToList();

            return View(events);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult EventDetails(int id)
        {
            if(id != 0)
            {
                var eventModel = _eventSetvice.GetEventById(id);

                return View(eventModel);
            }
            else
            {
                return View();
            }
        }
    }
}
