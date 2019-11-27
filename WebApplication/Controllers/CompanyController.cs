using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Authorize]
    [Route("parceiros")]
    public class CompanyController : Controller
    {
        [HttpGet("perfil")]
        public IActionResult Index()
        {
            return View();
        }
    }
}