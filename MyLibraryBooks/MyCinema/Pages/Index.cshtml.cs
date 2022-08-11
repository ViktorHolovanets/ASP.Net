using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyCinema.Pages
{
    public class IndexModel : PageModel
    {
        public LibraryDB context { get; private set; }
        public IEnumerable<Schedule> ScheduleToday { get; set; } = null!;
        public IndexModel(LibraryDB db)
        {
            context = db;
        }

        public void OnGet()
        {
            ScheduleToday = GetTodayFilms();
        }

        public IEnumerable<Schedule> GetFilm(Film film)
        {
            var t = ScheduleToday.Where(s => s.Film_id.Id == film.Id).ToList();
            return t;
        }

        public IActionResult OnPost(int id)
        {
            context.Schedules.RemoveRange(context.Schedules.Where(sc=>sc.Film_id.Id==id));
            context.SaveChanges();
            ScheduleToday = GetTodayFilms();
            return Page();
        }

        private IEnumerable<Schedule> GetTodayFilms()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");

           return context.Schedules.Include(c => c.Film_id).Where(s => s.Date == date).ToList();
        }
        public void OnPostSearch(string word)
        {
            ScheduleToday = String.IsNullOrEmpty(word)
                ? GetTodayFilms()
                : GetTodayFilms().Where(sc => sc.Film_id.Title.Contains(word));
        }
    }
}