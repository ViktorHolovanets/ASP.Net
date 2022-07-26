﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebShop.Entities.DB;
using MyWebShop.Lib;

namespace MyWebShop.Pages
{
    public class IndexModel : PageModel
    {
        ShopDB context;
        public User Client { get; set; } = null;
        public IndexModel(ShopDB db)
        {
            context = db;
            if (context.Categories.Count() == 0)
            {
                MyFunction.CreateBb(context);
            }
        }

        public void OnPost(User client)
        {
            var cl = context.Users.FirstOrDefault(p => p.Login == client.Login && p.Password == client.Password);
            if (cl != null)
            {
                Client = cl;
            }
            else
            {
                Client =client;
                context.Users.Add(client);
                context.SaveChanges();
            }
            Response.Cookies.Append("id", Client.Id.ToString());
        }

        public void OnGet()
        {
            if (Request.Cookies.ContainsKey("id"))
            {
                Client = context.Users.FirstOrDefault(p => p.Id == Int32.Parse(Request.Cookies["id"]));
            }
        }
        public void OnGetExit()
        {
            Response.Cookies.Delete("id");
        }
    }
}