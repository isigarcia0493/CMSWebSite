using CMSWebsite.Models;
using CMSWebsite.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class FormMessageController : Controller
    {
        private readonly IFormMessageService _formMessageService;

        public FormMessageController(IFormMessageService formMessageService)
        {
            _formMessageService = formMessageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var messages = _formMessageService.GetAllMessages().OrderByDescending(m => m.DateOfMessage).ToList();

            return View(messages);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var message = _formMessageService.GetMessageById(id);

            if(message != null)
            {
                return View(message);
            }
            else
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
        }

        [HttpGet]
        public IActionResult DeleteMessage(int id)
        {
            var message = _formMessageService.GetMessageById(id);

            if (message != null)
            {
                return View(message);
            }
            else
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
        }

        [HttpPost]
        public IActionResult DeleteMessage(FormMessage model)
        {
            var message = _formMessageService.GetMessageById(model.FormMessageId);

            if (message != null)
            {
                _formMessageService.DeleteMessage(message.FormMessageId);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("PageNotFound", "Dashboard");
            }
        }
    }
}
