using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Area("Partners")]
    [Route("parceiros/faturas")]
//    [Authorize]
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Faturas";
            return View();
        }
    }
}