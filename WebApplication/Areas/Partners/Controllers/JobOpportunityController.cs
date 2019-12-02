using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Area("Partners")]
    [Route("parceiros/oportunidades")]
    [Authorize]
    public class JobOpportunityController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Oportunidades";
            return View();
        }
    }
}