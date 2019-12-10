using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/eventos")]
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Eventos";
            return View();
        }
        
        [HttpGet("criar")]
        public IActionResult New()
        {
            ViewBag.Title = "Publicar Evento";
            return View();
        }
    }
}