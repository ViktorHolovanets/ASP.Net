using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyCinema.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditFilmModel : PageModel
    {
        public LibraryDB context { get; private set; }
        public EditFilmModel(LibraryDB db)
        {
            context = db;
        }
        [BindProperty]
        public Film? film { get; set; }
        public void OnGet(int id)
        {
            film=context.Films.FirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost()
        {
            context.Films.Update(film!);
            context.SaveChangesAsync();
            return OnPostCancel();
        }
        public IActionResult OnPostCancel()=> RedirectToPage("/Index");

    }
}
