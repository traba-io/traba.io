using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Interface;
using WebApplication.Models;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/oportunidades")]
    public class JobOpportunityController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IJobOpportunityService _jobOpportunityService;
        private readonly UserManager<User> _userManager;

        public JobOpportunityController(IJobOpportunityService jobOpportunityService, UserManager<User> userManager, IMapper mapper)
        {
            _jobOpportunityService = jobOpportunityService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageLimit = 10)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Title = "Oportunidades";
            var jobOpportunities = await _jobOpportunityService.Get(user, pageIndex, pageLimit);
            return View(jobOpportunities);
        }
        
        [HttpGet("criar")]
        public async Task<IActionResult> New()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.AvailableCompanies = user.Companies.Select(u => new SelectListItem(u.Company.Name, u.CompanyId.ToString())).ToList();
            ViewBag.Title = "Nova Oportunidade";
            return View();
        }
        
        [HttpPost("criar")]
        public async Task<IActionResult> New(JobOpportunityViewModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var job = _mapper.Map<JobOpportunity>(viewModel);
            await _jobOpportunityService.Save(job, user);
            return LocalRedirect(Url.Action("Index"));
        }
        
        [HttpGet("editar/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var job = await _jobOpportunityService.Get(id);
            var vm = _mapper.Map<JobOpportunityViewModel>(job);
            ViewBag.AvailableCompanies = user.Companies.Select(u => new SelectListItem(u.Company.Name, u.CompanyId.ToString())).ToList();
            ViewBag.Title = "Nova Oportunidade";
            return View("New", vm);
        }
        
        [HttpPost("editar/{id}")]
        public async Task<IActionResult> Edit(long id, JobOpportunityViewModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var job = _mapper.Map<JobOpportunity>(viewModel);
            job.Id = id;
            await _jobOpportunityService.Save(job, user);
            return LocalRedirect(Url.Action("Index"));
        }
    }
}