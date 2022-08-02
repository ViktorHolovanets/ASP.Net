using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebShop.Entities.DB;

namespace MyWebShop.Pages
{
    public class ShowCategoriesModel : PageModel
    {
        ShopDB context;
        [BindProperty(SupportsGet = true, Name = "category")]
        public string TypeCategory { get; set; }
        public int Id { get; set; }
        public ShowCategoriesModel(ShopDB db)
        {
            context = db;
        }
        public void OnGet( int id)
        {
            Id = id;
            // TypeCategory = category;
        }

        public IEnumerable<Product> GetCategory()=> context.Products.Where(p => p.category.Name == TypeCategory).ToList();

    }
}
