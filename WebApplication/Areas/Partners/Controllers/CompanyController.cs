using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Repository.Interface;
using WebApplication.Models;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/empresas")]
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly UserManager<User> _userManager;

        public CompanyController(IMapper mapper, ICompanyService companyService, UserManager<User> userManager)
        {
            _mapper = mapper;
            _companyService = companyService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index() 
        {
            var actor = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Title = "Empresas";
            var companies = await _companyService.Get(actor);
            return View(companies);
        }

        [HttpGet("criar")]
        public IActionResult New()
        {
            ViewBag.Title = "Nova empresa";
            return View();   
        }
        
        [HttpPost("criar")]
        public async Task<IActionResult> New(CompanyViewModel viewModel)
        {
            var actor = await _userManager.FindByNameAsync(User.Identity.Name);
            var company = _mapper.Map<Company>(viewModel);
            await _companyService.Save(company, actor);
            return LocalRedirect(Url.Action("Index"));
        }
    }
}