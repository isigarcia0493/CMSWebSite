using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CMSWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View("PageNotFound");
        }
    }
}
