using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("conta")]
    public class AccountController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}