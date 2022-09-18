using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportSite.Areas.Edit.ViewModels;
using SportSite.Models;
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
        private Account GetAccount(string? id = null)
        {
            return _context.Accounts?.Include(a => a.Client).FirstOrDefault(id != null ? a => a.Id.ToString() == id : a => a.Login == User.Identity.Name);
        }public int UnreadMessage()
        {
            return _context.Messages.Where(m => !m.IsRead).Count();
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
            return View(_context.GetUser(id) ?? GetAccount(id).Client);
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
                    var account = GetAccount();
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
            ViewBag.UnreadMessage = UnreadMessage();
            return View(GetAccount().Client);
        }
        [HttpGet]
        [Route("ViewUser")]
        public IActionResult ViewUsers(Role? role = Role.client)
        {
            var getlist = (from cl in _context.Accounts
                           where cl.Role == role
                           select cl.Client).ToList();
            return PartialView(getlist);
        }
        public IActionResult ViewCode()
        {
            var account = GetAccount();
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
        public IActionResult DeleteCode(string? id)
        {
            _context.Code.Remove(_context.Code.FirstOrDefault(a => a.Id.ToString() == id));
            _context.SaveChanges();
            var account = GetAccount();
            return View("ViewProfileManager");
        }
        public IActionResult Delete(string? id)
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
        //
        public IActionResult CreateTraining()
        {
            var tempCoaches = new List<ClassCoach>();
            foreach (var item in _context.Coaches.Include(c=>c.Account.Client))
            {
                tempCoaches.Add(new ClassCoach()
                {
                    Id = item.Id,
                    Name=$"{item.Account.Client.Name} {item.Account.Client.Surname}"
                });
            }
            ViewBag.Coaches = new SelectList(tempCoaches, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateTraining(ViewCreateTraining viewCreateTraining)
        {
            List<DayOfWeekTraining> dayOfWeekTrainings = new List<DayOfWeekTraining>();
            var c = _context.Coaches.FirstOrDefault(c => c.Id == viewCreateTraining.IdCoach);
            foreach (var item in viewCreateTraining.dayofWeeks)
            {
                dayOfWeekTrainings.Add(new DayOfWeekTraining()
                {
                    dayofWeek = item,
                    Time = viewCreateTraining.Time
                });
            }
            _context.Trainings.Add(new Training()
            {
                coach = _context.Coaches.FirstOrDefault(c => c.Id == viewCreateTraining.IdCoach),
                training = viewCreateTraining.typeTraining,
                dayofWeeks = dayOfWeekTrainings
            });
            _context.SaveChanges();
            return View();
        }
        public IActionResult GetMessage()
        {
            return PartialView(_context.Messages);
        }
    }
}
