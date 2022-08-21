using Microsoft.AspNetCore.Mvc;
using MVC_App.Models.DB;
using MVC_App.Models.Lib;
using MVC_App.ModelsViews;

namespace MVC_App.Controllers
{
    public class ShopController : Controller
    {
        ShopDB context;
        public ShopController(ShopDB db)
        {
            context = db;
            if (context.Categories.Count() == 0)
            {
                MyFunc.CreateBb(context);
            }
        }
        [Route("")]
        [Route("Task2")]
        [HttpGet]
        public IActionResult Task2()
        {
            if (Request.Cookies.ContainsKey("id"))
            {
                var cl = context.Users.FirstOrDefault(p => p.Id == Int32.Parse(Request.Cookies["id"]));
                return View(cl);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.IsUser = Request.Cookies.ContainsKey("id") ? true : false;
            return View(context.Products.FirstOrDefault(p => p.Id == id));
        }
        [HttpPost]
        public IActionResult Details()
        {
            int id = Int32.Parse(Request.Form["idProduct"].ToString());
            int idUser = Int32.Parse(Request.Cookies["id"].ToString());
            Product pr = context.Products.FirstOrDefault(pr => pr.Id == id);
            var cl = context.Users.FirstOrDefault(pr => pr.Id == idUser);
            context.Baskets.Add(new Basket() { Products_id = pr, User_id = cl });
            context.SaveChanges();
            ViewBag.IsUser = true;
            return View(pr);
        }
        [HttpPost]
        [Route("Task2")]
        public IActionResult Task2(User? user)
        {
            if (user.Login != null)
            {
                var cl = context.Users.FirstOrDefault(p => p.Login == user.Login && p.Password == user.Password);
                //user = cl;
                if (cl == null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    cl = context.Users.FirstOrDefault(p => p.Login == user.Login && p.Password == user.Password);
                }
                Response.Cookies.Append("id", cl.Id.ToString());
                return View(cl);
            }
            Response.Cookies.Delete("id");
            return View(null);
        }
        [Route("ShowCategories")]
        public IActionResult ShowCategories(string category)
        {
            return View(MyFunc.GetViewProducts(context.Products.Where(p => p.category.Name == category).ToList()));
        }
        [Route("MyBasket")]
        [HttpGet]
        public IActionResult MyBasket()
        {
            return View(Request.Cookies.ContainsKey("id") ? (from p in context.Baskets
                                                             where p.User_id.Id == Int32.Parse(Request.Cookies["id"])
                                                             orderby p
                                                             select p.Products_id).ToList() : null);
        }
        [Route("MyBasket")]
        [HttpPost]
        public IActionResult MyBasket(int id)
        {
            var t = context.Baskets.FirstOrDefault(p =>
                p.Products_id.Id == id && p.User_id.Id == Int32.Parse(Request.Cookies["id"]));
            if (t != null)
            {
                context.Baskets.Remove(t);
                context.SaveChanges();
            }
            return MyBasket();
        }
        public IActionResult AboutMyShop() => View();
    }
}
