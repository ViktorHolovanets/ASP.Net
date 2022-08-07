using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyCinema.Pages
{
    public class CreateFilmModel : PageModel
    {
        public LibraryDB context { get; private set; }

        public CreateFilmModel(LibraryDB db)
        {
            context = db;
        }

        public void OnPostAdd(Film f)
        {
            context.Films.Add(f);
            context.SaveChanges();
        }
    }
}
