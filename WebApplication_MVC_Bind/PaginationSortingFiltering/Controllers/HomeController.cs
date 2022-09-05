using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaginationSortingFiltering.Models;
using PaginationSortingFiltering.Models.DB;
using System.Diagnostics;

namespace PaginationSortingFiltering.Controllers
{
    public class HomeController : Controller
    {
        DbLibrary db;
        public HomeController(DbLibrary db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index(Categories? categori, SortState sortstate = SortState.TitleAsc, int page=0, bool issort=false)
        {
            var res = db.GetBooksSort(new ViewSortPage() { Page = page, Categori = categori, sortState = sortstate, IsSort=issort });
            return View( res);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Book? book = await db.Books!.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Book? book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null) return View(book);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            db.Books.Update(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}