using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/faturas")]
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Faturas";
            return View();
        }
    }
}