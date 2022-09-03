using Filters.Filters;
using Filters.Models;
using Filters.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Filters.Controllers
{
    [WriteCookie("Home", "15")]
    public class HomeController : Controller
    {
        Db db;
        public HomeController(Db db)
        {
            this.db = db;
        }
        [Color(Colors.tomato)]
        public IActionResult Index()
        {
            ViewBag.R = "ew";
            return View();
        }
        [Color(Colors.red)]
        public IActionResult Log()
        {
            return View(db.Visitors.OrderByDescending(v=>v.Id));
        }
        public IActionResult NotFound()
        {
            return View();
        }
        [Color(Colors.blue)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}