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
        private Account GetAccount(string? id=null)
        {
            return _context.Accounts?.Include(a => a.Client).FirstOrDefault(id != null ? a => a.Id.ToString() == id : a => a.Login == User.Identity.Name);
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IncorrectPassword(string oldpassword)
        {
            var account = GetAccount();
            return account?.Password == oldpassword ? Json(true) : Json(false);
        }
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        [Route("Edit/DetailsUser")]
        // GET: HomeController/Details/5
        public ActionResult DetailsUser(string? id)
        {
            return View(GetAccount(id)?.Client);
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(string? id)
        {
            return View(_context.GetUser(id)?? GetAccount(id).Client);
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
                    var account =GetAccount();
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
        [Authorize(Roles = "manager")]
        public ActionResult ViewProfileManager()
        {
            return View();
        }
        [HttpGet]
        [Route("ViewUser")]
        public IActionResult ViewUsers(Role? role=Role.client)
        {
            var getlist = (from cl in _context.Accounts 
                           where cl.Role==role
                           select cl.Client).ToList();
            return PartialView(getlist);
        }
        public IActionResult ViewCode()
        {
            var account=GetAccount();
            return PartialView(_context.Code.Where(c => c.Сreator == account.Id));
        }
       
        public IActionResult CreateCode()
        {
            _context.Code.Add(new CreateCodeAccounts()
            {
                Code = Guid.NewGuid(),
                Сreator = GetAccount().Id
            });
            _context.SaveChanges();
            var account = GetAccount();
            return PartialView("Viewcode", _context.Code.Where(c => c.Сreator == account.Id));
        }
        public ActionResult Delete(string? id)
        {
            try
            {
                _context.Accounts.Remove(_context.Accounts.FirstOrDefault(a => a.Client.Id.ToString() == id));
                _context.SaveChanges();
            }
            catch
            {
                return View("ViewProfileManager");
            }
            return View("ViewProfileManager");
        }
    }
}
