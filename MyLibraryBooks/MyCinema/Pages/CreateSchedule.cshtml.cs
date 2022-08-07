using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyCinema.Pages
{
    public class CreateScheduleModel : PageModel
    {
        public LibraryDB context { get; private set; }
        [BindProperty]
        public Schedule Schedule { get; set; }
        [BindProperty]
        public int film_id { get;set; }
        public CreateScheduleModel(LibraryDB db)
        {
            context = db;
        }

        public void OnPost()
        {
            Schedule.Film_id = context.Films.Find(film_id);
            context.Schedules.Add(Schedule);
            context.SaveChanges();
        }
    }
}
