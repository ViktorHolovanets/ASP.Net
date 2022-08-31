using Microsoft.AspNetCore.Mvc;
using ViewComponent_ASP_MVC.Models;

namespace ViewComponent_ASP_MVC.Componets
{
    public class EditUserViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ResultUser user) => View(user);
    }
}

