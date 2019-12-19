using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public CompanyController(IMapper mapper, ICompanyService companyService, UserManager<User> userManager,
            IFileUploaderService fileUploader)
        {
            _mapper = mapper;
            _companyService = companyService;
            _userManager = userManager;
            _fileUploader = fileUploader;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageLimit = 10)
        {
            var actor = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Title = "Empresas";
            var companies = await _companyService.Get(actor, pageIndex, pageLimit);
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

            if (viewModel.ProfilePictureUpload != null)
            {
                await using var fileMemoryStream = new MemoryStream();
                viewModel.ProfilePictureUpload.CopyTo(fileMemoryStream);
                var fileName = Guid.NewGuid().ToString("N") +
                               Path.GetExtension(viewModel.ProfilePictureUpload.FileName).ToLower();
                company.ProfilePicture = await _fileUploader.Upload(fileMemoryStream, fileName);
            }

            await _companyService.Save(company, actor);
            return LocalRedirect(Url.Action("Index"));
        }

        [HttpGet("editar/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            var company = await _companyService.Get(id);
            var mappedCompany = _mapper.Map<CompanyViewModel>(company);
            ViewBag.Title = mappedCompany.Name;
            ViewData["CompanyId"] = company.Id;
            return View("New", mappedCompany);
        }

        [HttpPost("editar/{id}")]
        public async Task<IActionResult> Edit(long id, CompanyViewModel viewModel)
        {
            var actor = await _userManager.FindByNameAsync(User.Identity.Name);
            var company = _mapper.Map<Company>(viewModel);
            company.Id = id;

            if (viewModel.ProfilePictureUpload != null)
            {
                await using var fileMemoryStream = new MemoryStream();
                viewModel.ProfilePictureUpload.CopyTo(fileMemoryStream);
                var fileName = Guid.NewGuid().ToString("N") +
                               Path.GetExtension(viewModel.ProfilePictureUpload.FileName).ToLower();
                company.ProfilePicture = await _fileUploader.Upload(fileMemoryStream, fileName);
            }

            await _companyService.Save(company, actor);
            return LocalRedirect(Url.Action("Index"));
        }

        [HttpGet("colaborador/{companyId}/{email}")]
        public async Task<IActionResult> CheckUserCompany(long companyId, string email)
        {
            email = Encoding.UTF8.GetString(Convert.FromBase64String(email));
            if (User.Identity.Name == email)
                return BadRequest(new {message = "Não é possível adicionar a si mesmo em uma empresa."});
            
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return NotFound();
            
            var alreadyExistsOnCompany = await  _companyService.CheckExistence(companyId, user.Id);
            
            if(alreadyExistsOnCompany)
                return BadRequest(new {message = "Usuário já está cadastrado na empresa."});

            return Ok(new {name = user.Name, email = user.Email});
        }

        [HttpPost("colaborador")]
        public async Task<IActionResult> AddUserCompany(UserCompanyViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.CollaboratorEmail);
            var userCompany = new UserCompany()
            {
                CompanyId = viewModel.CompanyId,
                UserId = user.Id
            };
            await _companyService.Save(userCompany);
            return LocalRedirect(Url.Action("Edit", new {id = viewModel.CompanyId}));
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