using CMSWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMSWebsite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Content("success");
            }
            else
            {
                return View(model);
            }
        }
    }
}
