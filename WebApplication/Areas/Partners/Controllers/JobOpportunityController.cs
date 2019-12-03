using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/oportunidades")]
    public class JobOpportunityController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Oportunidades";
            return View();
        }
        
        [HttpGet("criar")]
        public IActionResult New()
        {
            ViewBag.Title = "Nova Oportunidade";
            return View();
        }
    }
}