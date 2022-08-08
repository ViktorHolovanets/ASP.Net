using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibraryBooks.Pages
{
    public class MyLibraryModel : PageModel
    {
        public LibraryDB context { get; private set; }
        [BindProperty]
        public Book book { get; set; }=null!;
        [BindProperty]
        public IEnumerable<Book> books { get; set; } = null!;
        public MyLibraryModel(LibraryDB db)
        {
            context = db;
        }

        public void OnPostEdit(int id)
        {
            book = context.Books.FirstOrDefault(b => b.Id == id);
            books = null;
            
        }
        public void OnPostEdits(int id)
        {
            context.Books.Update(book!);
            context.SaveChanges();
            books = null;
            book = null;
        }
        public void OnPostDelete(int id)
        {
            var book_d = context.Books.FirstOrDefault(b => b.Id == id);
            if (book_d != null)
            {
                context.Books.Remove(book_d);
                context.SaveChanges();
            }
            books = null;
            book = null;
        }
        public void OnPostSearch(string word)
        {
            books= context.Books.Where(b=>b.Title.Contains(word)|| b.Authors.Contains(word)).ToList();
            if (books.Count() == 0)
                books = null;
            book = null;
        }
    }
}
