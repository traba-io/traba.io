using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/oportunidades")]
    public class JobOpportunityController : Controller
    {
        private readonly IJobOpportunityService _jobOpportunityService;
        private readonly UserManager<User> _userManager;

        public JobOpportunityController(IJobOpportunityService jobOpportunityService, UserManager<User> userManager)
        {
            _jobOpportunityService = jobOpportunityService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageLimit = 10)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Title = "Oportunidades";
            var jobOpportunities = await _jobOpportunityService.Get(user, pageIndex, pageLimit);
            return View(jobOpportunities);
        }
        
        [HttpGet("criar")]
        public IActionResult New()
        {
            ViewBag.Title = "Nova Oportunidade";
            return View();
        }
    }
}