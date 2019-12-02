using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Interface;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobOpportunityService _jobOpportunity;
        private readonly ICompanyService _companyService;
        
        public HomeController(IJobOpportunityService jobOpportunity, ICompanyService companyService)
        {
            _jobOpportunity = jobOpportunity;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageLimit = 10)
        {
            var jobs = await _jobOpportunity.Get(pageIndex, pageLimit);
            return View(jobs);
        }

        [HttpGet("empresas/{companyNamespace}")]
        public async Task<IActionResult> Company(string companyNamespace)
        {
            var company = await _companyService.Get(companyNamespace);
            
            if (company is null)
                return NotFound();
            
            return View(company);
        }
        
        [HttpGet("empresas")]
        public IActionResult Companies(int pageIndex = 1, int pageLimit = 10)
        {
            return View();
        }
        
        [HttpGet("empresas/{companyNamespace}/vagas/{jobOpportunityUri}")]
        public async Task<IActionResult> JobOpportunity(string companyNamespace, string jobOpportunityUri)
        {
            var job = await _jobOpportunity.Get(companyNamespace, jobOpportunityUri);
            return View(job);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}