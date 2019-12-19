using System.Net;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace WebApplication.Areas.Partners.Controllers
{
    [Authorize]
    [Area("Partners")]
    [Route("parceiros/faturas")]
    [FeatureGate(FeatureManagement.Invoices)]
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Faturas";
            return View();
        }
    }
}