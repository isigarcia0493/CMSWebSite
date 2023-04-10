using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly IEventRegistrationService _eventRegistrationService;
        private readonly IEventService _eventService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistrationController(IRegistrationService registrationService, IEventRegistrationService eventRegistrationService, IEventService eventService, UserManager<ApplicationUser> userManager)
        {
            _registrationService = registrationService;
            _eventRegistrationService = eventRegistrationService;
            _eventService = eventService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if(id != null)
            {
                var eventRegistrations = _eventRegistrationService.GetAllEventRegistration().Where(e => e.EventId == id);

                foreach(var item in eventRegistrations)
                {
                    item.Registration = _registrationService.GetRegistrationById(item.RegistrationId);
                    item.Registration.Events = _eventService.GetAllEvents().Where(e => e.EventId == item.EventId).ToList();
                }

                var eventModel = _eventService.GetEventById((int)id);
                ViewBag.Event = eventModel.EventName;

                return View(eventRegistrations);
            }
            else
            {
                return RedirectToAction("Index", "Event");
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var registration = _registrationService.GetRegistrationById(id);
            var eventRegistrations = _eventRegistrationService.GetAllEventRegistration().Where(er => er.EventId == id);

            if (registration == null)
            {
                return RedirectToAction("NotFound404", "Home");
            }
            else
            {
                registration.Events = _registrationService.GetEventsByRegistrationId(id).ToList();
            }

            return View(registration);
        }
    }
}
