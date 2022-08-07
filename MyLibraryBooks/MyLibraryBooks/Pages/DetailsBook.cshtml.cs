using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibraryBooks.Pages
{
    [IgnoreAntiforgeryToken]
    public class DetailsBookModel : PageModel
    {
        LibraryDB context;
        public DetailsBookModel(LibraryDB db)
        {
            context = db;
        }
        [BindProperty] public Book book { get; set; }

        public IActionResult OnPostAddBook()
        {
            Book t = context.Books.FirstOrDefault(b => b.Title == book.Title && b.Authors == book.Authors);
            if (t == null)
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            return Page();
        }
    }
}
