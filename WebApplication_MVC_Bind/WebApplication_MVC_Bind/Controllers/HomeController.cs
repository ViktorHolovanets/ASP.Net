using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_MVC_Bind.Models;

namespace WebApplication_MVC_Bind.Controllers
{
    public class HomeController : Controller
    {
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Index()
        {
            return View(SingletonDb.getInstance());
        }
        [HttpPost]
        public IActionResult Index(Account account)
        {
            SingletonDb.getInstance()._accounts.Add(account);
            return Index();
        }
        public IActionResult CreateUser(User user)
        {
            SingletonDb.getInstance()._users.Add(user);
            return View("Index", SingletonDb.getInstance());
        }
        public IActionResult CreateEmploy([FromQuery] Employ employ)
        {
            employ.Id = SingletonDb.idEmploy++;
            SingletonDb.getInstance()._employs.Add(employ);
            return View("Index", SingletonDb.getInstance());
        }
        public IActionResult CreateDateTime()
        {
            var form = Request.Form;
            string date = form["date"];
            string time = form["time"];
            string iString = date+" "+time;
            DateTime MyDate = DateTime.Parse(iString);
            SingletonDb.getInstance().MyDateTimes.Add(MyDate);
            return View("Index", SingletonDb.getInstance());
        }
    }
}