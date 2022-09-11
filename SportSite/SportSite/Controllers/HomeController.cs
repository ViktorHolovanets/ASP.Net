﻿using Microsoft.AspNetCore.Authentication;
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
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsLogin(string login)
        {
            return db.Accounts.FirstOrDefault(u => u.Login == login) != null ? Json(false) : Json(true);
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
                db.Accounts.Add(user);
                db.SaveChanges(); 

                return Login(new EnterUserView() { Login=user.Login, Password=user.Password}).Result;
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