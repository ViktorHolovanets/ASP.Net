using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebShop.Entities.DB;

namespace MyWebShop.Pages
{
    public class MyBasketModel : PageModel
    {
        ShopDB context;
        public MyBasketModel(ShopDB db)
        {
            context = db;
        }

        public List<Product> ProductsBasket { get; set; } = null;
        public void OnGet()
        {
            if (Request.Cookies.ContainsKey("id"))
            {
                ProductsBasket = (from p in context.Baskets
                                  where p.User_id.Id == Int32.Parse(Request.Cookies["id"])
                                  orderby p
                                  select p.Products_id).ToList();
            }
        }

        public void OnPost(int id)
        {
            var t = context.Baskets.FirstOrDefault(p =>
                p.Products_id.Id == id && p.User_id.Id == Int32.Parse(Request.Cookies["id"]));
            if (t != null)
            {
                context.Baskets.Remove(t);
                context.SaveChanges();
            }
            ProductsBasket = (from p in context.Baskets
                              where p.User_id.Id == Int32.Parse(Request.Cookies["id"])
                              orderby p
                              select p.Products_id).ToList();
        }
    }
}
