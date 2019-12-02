using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Area("Partners")]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActiveMenu"] = "dashboard";
            ViewBag.Title = "Dashboard";
            return View();
        }
    }
}