using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Enum;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("conta")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        
        [HttpGet("entrar")]
        public IActionResult Login()
        {
            ViewBag.Title = "Entrar";
            return View();
        }
        
        [HttpPost("entrar")]
        public async Task<IActionResult> Login(LoginViewModel viewModel, [FromQuery] string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email,
                viewModel.Password, viewModel.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");
                ViewBag.Title = "Entrar";
                return View();
            }
        }
        
        [HttpGet("esqueci-minha-senha")]
        public IActionResult ForgotPassword()
        {
            ViewBag.Title = "Esqueci minha senha";
            return View();
        }
        
        [HttpPost("esqueci-minha-senha")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Action("RecoveryPassword", "Account",
                new {userId = user.Id, code = resetToken}, Request.Scheme);
            
            await _emailService.SendEmail(viewModel.Email, "Crie sua nova senha!", EmailTemplateType.ResetPassword,
                new {resetPasswordUrl = callbackUrl});
            
            ViewBag.Title = "Esqueci minha senha";
            return View();
        }

        [HttpGet("recuperar-senha")]
        public IActionResult RecoveryPassword()
        {
            ViewBag.Title = "Recuperar senha";
            return View();
        }
        
        [HttpPost("recuperar-senha")]
        public async Task<IActionResult> RecoveryPassword(RecoveryPasswordViewModel viewModel, [FromQuery] string userId, [FromQuery] string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var resetToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ResetPasswordAsync(user, resetToken, viewModel.Password);
            if(result.Succeeded) return LocalRedirect(Url.Action("Login"));
            ViewBag.Title = "Recuperar senha";
            return View();
        }
        
        [HttpGet("criar-conta")]
        public IActionResult CreateAccount()
        {
            ViewBag.Title = "Criar conta";
            return View();
        }
        
        [HttpGet("confirmar-conta")]
        public async Task<IActionResult> ConfirmAccount([FromQuery] string userId, [FromQuery] string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var confirmAccountCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            await _userManager.ConfirmEmailAsync(user, confirmAccountCode);
            ViewBag.Title = "Confirmar conta";
            return LocalRedirect(Url.Action("Login"));
        }
        
        [HttpPost("criar-conta")]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel viewModel, [FromQuery] string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var mappedUser = _mapper.Map<User>(viewModel);
            var result = await _userManager.CreateAsync(mappedUser, viewModel.Password);
            if (result.Succeeded)
            {
                var confirmAccountCode = await _userManager.GenerateEmailConfirmationTokenAsync(mappedUser);
                confirmAccountCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmAccountCode));
                
                var callbackUrl = Url.Action("ConfirmAccount", "Account",
                    new {userId = mappedUser.Id, code = confirmAccountCode}, Request.Scheme);

                await _emailService.SendEmail(viewModel.Email, "Confirme sua conta!", EmailTemplateType.ConfirmAccount,
                    new {confirmAccountUrl = callbackUrl});
                
                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return RedirectToPage("RegisterConfirmation", 
                        new { email = viewModel.Email });
                }
                else
                {
                    await _signInManager.SignInAsync(mappedUser, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            
            ViewBag.Title = "Criar conta";
            
            return View();
        }
    }
}