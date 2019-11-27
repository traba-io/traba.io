using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Authorize]
    [Route("parceiros")]
    public class PartnersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}