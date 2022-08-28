using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TagHtml_Helper.Models;

namespace TagHtml_Helper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsUsers = Singleton.getInstance().users.Count() > 0 ? true : false;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            Singleton.getInstance().users.Add(user);
            ViewBag.IsUsers = true;
            return View("Index");
        }
        public IActionResult ViewUsers()
        {
            return View(Singleton.getInstance().users);
        }
        public IActionResult EditUser(string? Id)
        {
            return View(Singleton.getInstance().users.FirstOrDefault(u=>u.Id==Id));
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            var temp_user = Singleton.getInstance().users.FirstOrDefault(u => u.Id == user.Id);
            Singleton.getInstance().users.Remove(temp_user);
            Singleton.getInstance().users.Add(user);
            return View("ViewUsers", Singleton.getInstance().users);
        }
    }
}