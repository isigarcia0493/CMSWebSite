using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using System.Linq;

namespace CMSWebsite.Controllers
{
    public class FormMessageController : Controller
    {
        private readonly IFormMessageService _formMessageService;
        private readonly UserManager<ApplicationUser> _userManager;

        public FormMessageController(IFormMessageService formMessageService, UserManager<ApplicationUser> userManager)
        {
            _formMessageService = formMessageService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userManager.Users.Where(u => u.Email == User.Identity.Name).ToList();

            FormMessage message = new FormMessage();

            if (user.Count > 0)
            {
                message.FirstName = user[0].FirstName;
                message.LastName = user[0].LastName;
                message.UserId = user[0].Id;
            }

            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMessage(FormMessage model)
        {
            if (ModelState.IsValid)
            {
                _formMessageService.AddMessage(model);

                TempData["success"] = "Message Sent Successfully";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index", model);
            }
        }
    }
}
