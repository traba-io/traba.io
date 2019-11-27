using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("sobre")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}