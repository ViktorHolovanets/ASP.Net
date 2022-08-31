using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using ViewComponent_ASP_MVC.Library;
using ViewComponent_ASP_MVC.Models;

namespace ViewComponent_ASP_MVC.Components
{
    public class UserViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ResultUser user=null) => View(user == null?ResultUser.CreateUser():user);
    }
}
