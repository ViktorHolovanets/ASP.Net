using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportSite.Areas.Edit.ViewModels;
using SportSite.Models.Db;

namespace SportSite.Areas.Edit.Controllers
{
    [Authorize]
    [Area("Edit")]
    public class HomeController : Controller
    {
        Db _context;
        public HomeController(Db context)
        {
            _context = context;
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IncorrectPassword(string oldpassword)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Login == User.Identity.Name);
            return account?.Password == oldpassword ? Json(true) : Json(false);
        }
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        [Route("Edit/DetailsUser")]
        // GET: HomeController/Details/5
        public ActionResult DetailsUser()
        {
            var accunt = _context.Accounts.Include(a => a.Client).FirstOrDefault(a => a.Login == User.Identity.Name);
            return View(accunt.Client);
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit()
        {
            var accunt = _context.Accounts.Include(a => a.Client).FirstOrDefault(a => a.Login == User.Identity.Name);
            return View(accunt.Client);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("DetailsUser");
            }
            catch
            {
                return View("DetailsUser");
            }
        }
        // GET: HomeController/Edit/5
        public ActionResult EditPassword()
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(ViewEditPassword? newpassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = _context.Accounts.FirstOrDefault(a => a.Login == User.Identity.Name);
                    account.Password = newpassword.Password;
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("DetailsUser");
            }
            catch
            {
                return View("DetailsUser");
            }
        }
        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
