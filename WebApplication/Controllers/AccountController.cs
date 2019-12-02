using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using WebApplication.Models;

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
        
        [HttpPost("entrar")]
        public IActionResult Login(LoginViewModel viewModel)
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
        
        [HttpPost("criar-conta")]
        public IActionResult CreateAccount(CreateAccountViewModel viewModel)
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