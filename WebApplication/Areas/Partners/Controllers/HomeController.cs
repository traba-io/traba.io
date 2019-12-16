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
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICompanyService _companyService;
        private readonly IJobOpportunityService _jobOpportunityService;

        public HomeController(ICompanyService companyService, IJobOpportunityService jobOpportunityService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _companyService = companyService;
            _jobOpportunityService = jobOpportunityService;
        }

        public async Task<IActionResult> Index()
        {
            var actor = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["Companies"] = actor.Companies.Count;
            ViewData["JobOpportunities"] = await _jobOpportunityService.Count(actor);
            return View();
        }
    }
}