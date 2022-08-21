using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;
using MVC_App.Models.DB;
using System.Diagnostics;
using MVC_App.Models.Lib;

namespace MVC_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        
        public IActionResult Task1()
        {
            ViewBag.SystemInformation = $"{Environment.OSVersion}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}