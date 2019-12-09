using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Repository.Extensions;
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
        private readonly IFileUploaderService _fileUploader;
        private readonly UserManager<User> _userManager;

        public CompanyController(IMapper mapper, ICompanyService companyService, UserManager<User> userManager, IFileUploaderService fileUploader)
        {
            _mapper = mapper;
            _companyService = companyService;
            _userManager = userManager;
            _fileUploader = fileUploader;
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
        
        [HttpGet("editar/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            var company = await _companyService.Get(id);
            var mappedCompany = _mapper.Map<CompanyViewModel>(company);
            ViewBag.Title = mappedCompany.Name;
            return View("New", mappedCompany);   
        }
        
        [HttpPost("editar/{id}")]
        public async Task<IActionResult> Edit(long id, CompanyViewModel viewModel)
        {
            var actor = await _userManager.FindByNameAsync(User.Identity.Name);
            var company = _mapper.Map<Company>(viewModel);
            company.Id = id;
            await _companyService.Save(company, actor);
            return LocalRedirect(Url.Action("Index"));
        }
        
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await using var fileMemoryStream = new MemoryStream();
            file.CopyTo(fileMemoryStream);
            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName).ToLower();
            var path = await _fileUploader.Upload(fileMemoryStream, fileName);
            return Ok(path);
        }
    }
}