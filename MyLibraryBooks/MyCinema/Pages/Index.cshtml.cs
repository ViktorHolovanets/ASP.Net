using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyCinema.Pages
{
    public class IndexModel : PageModel
    {
        public LibraryDB context { get; private set; }
        public IEnumerable<Schedule> ScheduleToday { get; set; } = null;
        public IndexModel(LibraryDB db)
        {
            context = db;
        }

        public void OnGet()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            ScheduleToday = context.Schedules.Include(c => c.Film_id).Where(s => s.Date == date).ToList();
        }

        public IEnumerable<Schedule> GetFilm(Film film)
        {
            var t = ScheduleToday.Where(s => s.Film_id.Id == film.Id).ToList();
            return t;
        }
    }
}