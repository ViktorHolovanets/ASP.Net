using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebShop.Entities.DB;

namespace MyWebShop.Pages
{
    public class DetailsModel : PageModel
    {
        ShopDB context;
        public Product Product { get; set; } = null;
        public DetailsModel(ShopDB db)
        {
            context = db;
        }
        public void OnGet(int id)
        {
            Product = context.Products.FirstOrDefault(pr => pr.Id == id);
        }
        public void OnPost(int idClient, int idProduct)
        {
            Product = context.Products.FirstOrDefault(pr => pr.Id == idProduct);
            var cl= context.Users.FirstOrDefault(pr => pr.Id == idClient);
            context.Baskets.Add(new Basket() {Products_id = Product, User_id = cl});
            context.SaveChanges();
        }
    }
}
