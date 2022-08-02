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

        public List<Product> Products { get; set; } = null;
        public ShowCategoriesModel(ShopDB db)
        {
            context = db;
        }
        
        public  IEnumerable<Product> GetCategory()=> context.Products.Where(p => p.category.Name == TypeCategory).ToList();

        public void OnGetOrderByDescending()
        {
            Products = GetCategory().OrderByDescending(p => p.Price).ToList();
        }
        public void OnGetOrderBy()
        {
            Products = GetCategory().OrderBy(p => p.Price).ToList();
        }
    }
}
