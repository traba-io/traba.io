using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("conta")]
    public class AccountController : Controller
    {
        [HttpGet("entrar")]
        public IActionResult Login()
        {
            ViewBag.Title = "Entrar";
            return View();
        }
        
        [HttpGet("esqueci-minha-senha")]
        public IActionResult ForgotPassword()
        {
            ViewBag.Title = "Esqueci minha senha";
            return View();
        }
        
        [HttpGet("criar-conta")]
        public IActionResult CreateAccount()
        {
            ViewBag.Title = "Criar conta";
            return View();
        }
        
        [HttpGet("recuperar-senha")]
        public IActionResult RecoveryPassword()
        {
            ViewBag.Title = "Recuperar senha";
            return View();
        }
    }
}