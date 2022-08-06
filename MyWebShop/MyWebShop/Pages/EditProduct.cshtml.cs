using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebShop.Entities.DB;

namespace MyWebShop.Pages
{
    public class EditProductModel : PageModel
    {
        ShopDB context;
        [BindProperty]
        public Product ProductId { get; set; }
        public EditProductModel(ShopDB db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ProductId = await context.Products.FindAsync(id);
            if (ProductId == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Products.Update(ProductId!);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
