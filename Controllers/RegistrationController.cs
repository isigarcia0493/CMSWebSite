using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using CMSWebsite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Linq;

namespace CMSWebsite.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly IEventService _eventService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEventRegistrationService _eventRegistrationService; 
        public RegistrationController(IRegistrationService registrationService, IEventService eventService, UserManager<ApplicationUser> userManager, IEventRegistrationService eventRegistrationService)
        {
            _registrationService = registrationService;
            _eventService = eventService;
            _userManager = userManager;
            _eventRegistrationService = eventRegistrationService;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var eventModel = _eventService.GetEventById(id);
            EventRegistrationViewModel registrationVM = new EventRegistrationViewModel();            

            if (eventModel != null)
            {
                registrationVM.Event = eventModel;

                return View(registrationVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRegistration(EventRegistrationViewModel model)
        {
            if (model != null)
            {
                var users = _userManager.Users.Where(u => u.Email == User.Identity.Name).ToList();
                Registration registration = new Registration()
                {
                    RegistrationDate = DateTime.Now,
                    PeopleAttending = model.Registration.PeopleAttending,
                    Accomodations = model.Registration.Accomodations,
                    DescribeAccomodations = model.Registration.DescribeAccomodations
                };

                if (users.Count > 0)
                {
                    registration.UserId = users[0].Id;
                }


                _registrationService.AddRegistration(registration);

                EventRegistration eventRegistration = new EventRegistration()
                {
                    RegistrationId = registration.RegistrationId,
                    EventId = model.Event.EventId
                };

                _eventRegistrationService.AddEventRegistration(eventRegistration);

                return RedirectToAction("Index", "Event");
            }
            else
            {
                return View(model);
            }
        }
    }
}
