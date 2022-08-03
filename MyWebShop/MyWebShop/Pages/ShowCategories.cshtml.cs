using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebShop.Entities.DB;

namespace MyWebShop.Pages
{
    public class ShowCategoriesModel : PageModel
    {
        ShopDB context;
        

        public List<Product> Products { get; set; } = null;
        public ShowCategoriesModel(ShopDB db)
        {
            context = db;
        }
        [BindProperty(SupportsGet = true, Name = "category")]
        public string TypeCategory { get; set; }
        [BindProperty(SupportsGet = true, Name = "typesort")]
        public string TypeSort { get; set; }
        [BindProperty(SupportsGet = true, Name = "typesort2")]
        public string TypeSort2 { get; set; }
        public IEnumerable<Product> GetCategory() => TypeSort switch
        {
            "name" => context.Products.Where(p => p.category.Name == TypeCategory).ToList().OrderBy(p => p.Name),
            "price" => context.Products.Where(p => p.category.Name == TypeCategory).ToList().OrderBy(p => p.Price),
            _ => context.Products.Where(p => p.category.Name == TypeCategory).ToList()
        };
            

        public void OnGetOrderByDescending()
        {
            TypeSort ??= TypeSort2;
            switch (TypeSort)
            {
                case "name":
                    Products = GetCategory().OrderByDescending(p => p.Name).ToList();
                    break;
                case "price":
                    Products = GetCategory().OrderByDescending(p => p.Price).ToList();
                    break;
                default:break;
            }
            //Products = GetCategory().OrderByDescending(p => p.Price).ToList();
        }
        public void OnGetOrderBy()
        {
            TypeSort ??= TypeSort2;
            Products = GetCategory().ToList();
        }
    }
}
