using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Authorize]
    [Route("parceiros")]
    public class JobOpportunityController : Controller
    {
        [HttpGet("vagas")]
        public IActionResult Index()
        {
            return View();
        }
    }
}