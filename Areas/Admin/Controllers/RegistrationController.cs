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
            if(id == null)
            {
                var registrations = _registrationService.GetAllRegistrations();
                var users = _userManager.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                List<EventRegistration> eventRegistrations = _eventRegistrationService.GetAllEventRegistration().ToList();


                foreach (var registration in registrations)
                {
                    foreach (var eventRegistration in eventRegistrations)
                    {
                        registration.Events = _eventService.GetAllEvents().Where(e => e.EventId == eventRegistration.EventId).ToList();
                    }

                    registration.User = _userManager.Users.Where(u => u.Id == registration.UserId).FirstOrDefault();
                }

                return View(registrations);
            }
            else
            {
                var registrations = _registrationService.GetAllRegistrations();
                List<Registration> newRegistrations = new List<Registration>();
                var users = _userManager.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                List<EventRegistration> eventRegistrations = _eventRegistrationService.GetAllEventRegistration().ToList();

                foreach (var registration in registrations)
                {
                    foreach (var eventRegistration in eventRegistrations)
                    {
                        if(eventRegistration.EventId == id)
                        {
                            registration.Events = _eventService.GetAllEvents().Where(e => e.EventId == eventRegistration.EventId).ToList();
                            registration.User = _userManager.Users.Where(u => u.Id == registration.UserId).FirstOrDefault();

                            newRegistrations.Add(registration);
                        }
                    }                   
                }

                var eventModel = _eventService.GetEventById((int)id);
                ViewBag.Event = eventModel.EventName;

                return View(newRegistrations);
            }
        }
    }
}
