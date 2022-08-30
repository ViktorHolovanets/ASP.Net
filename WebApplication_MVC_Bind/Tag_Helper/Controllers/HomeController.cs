using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tag_Helper.Models;

namespace Tag_Helper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CreditCard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreditCard(BankCard card)
        {
            card.Id= Guid.NewGuid().ToString();
            // Відповідна логіка
            ViewBag.Message = "Add Credit card";
            return View("Index");
        }
        public IActionResult User()
        {
            return View();
        }
        [HttpPost]
        public IActionResult User(User user)
        {
            ViewBag.Message = $"Add User {user.FirstName} {user.LastName}";
            user.SetBirthday(Request.Form["date"]);
            // Відповідна логіка
            return View("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}