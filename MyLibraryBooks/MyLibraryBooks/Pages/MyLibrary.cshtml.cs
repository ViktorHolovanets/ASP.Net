using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibraryBooks.Pages
{
    public class MyLibraryModel : PageModel
    {
        public LibraryDB context { get;private set; }

        public MyLibraryModel(LibraryDB db)
        {
            context = db;
        }
    }
}
