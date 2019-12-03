using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/empresas")]
    public class CompanyController : Controller
    {
        public IActionResult Index() 
        {
            ViewBag.Title = "Empresas";
            return View();
        }

        [HttpGet("criar")]
        public IActionResult New()
        {
            ViewBag.Title = "Nova empresa";
            return View();   
        }
    }
}