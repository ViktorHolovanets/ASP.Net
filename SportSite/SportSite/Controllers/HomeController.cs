using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportSite.Filters;
using SportSite.Models;
using SportSite.Models.Db;
using SportSite.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace SportSite.Controllers
{
   
    public class HomeController : Controller
    {
        Db db;
        public HomeController(Db db)
        {
            this.db = db;
            if (db.TypeSports.Count() < 1)
            {
                db.AddTypeSport();
            }
        }
        [AcceptVerbs("Get", "Post")] 
        public IActionResult IsLogin(string login)
        {
            return db.Accounts.FirstOrDefault(u => u.Login == login) != null ? Json(false) : Json(true);
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsCode(string createcode)
        {
            return db.Code.FirstOrDefault(code => code.Code.ToString() == createcode) == null ? Json(false) : Json(true);
        }
        public IActionResult CreateAccount()
        {       
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(Account user)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(new Client { Account=user});
                db.SaveChanges(); 

                return Login(new EnterUserView() { Login=user.Login, Password=user.Password}).Result;
            }
            return View();
        }

        public IActionResult CreateAccountCoach()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccountCoach(CreateAccountCoachView coach)
        {
            if (ModelState.IsValid)
            {
                coach.account.Role = Role.coach;
                db.Trainers.Add(new Trainer { Account = coach.account, Details= coach.Details });
                db.Code.Remove(db.Code.FirstOrDefault(c => c.Code == coach.CreateCode));
                db.SaveChanges();

                return Login(new EnterUserView() { Login = coach.account.Login, Password = coach.account.Password }).Result;
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(EnterUserView? model)
        {
            if (ModelState.IsValid)
            {
                Account user = await db.Accounts.Include(a=>a.Client).FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Privacy");
                }
                ViewBag.Message = "Incorrect login and (or) password";
            }
            return View("Index", db.TypeSports);
        }









        [Route("")]
        public IActionResult Index()
        {         
            return View(db.TypeSports);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
                //RedirectToRoute("Account", new { area = "Account", controller = "Home", action = "Index" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task Authenticate(Account user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
       
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}