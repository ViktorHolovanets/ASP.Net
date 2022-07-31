using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebShop.Entities.DB;

namespace MyWebShop.Pages
{
    public class ShowCategoriesModel : PageModel
    {
        ShopDB context;
        public string TypeCategory { get; private set; }
        public ShowCategoriesModel(ShopDB db)
        {
            context = db;
        }
        public void OnGet(string category)
        {
            TypeCategory = category;
        }

        public IEnumerable<Product> GetCategory()
        {
            var r = context.Products.Where(p => p.category.Name == TypeCategory).ToList();
            return r;
        }
    }
}
