using System.Text.Json;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ViewComponent_ASP_MVC.Library;
using ViewComponent_ASP_MVC.Models;

namespace ViewComponent_ASP_MVC.Componets
{
    [ViewComponent]
    public class TagImage
    {
        public IViewComponentResult Invoke(string src="")
        {
            return new HtmlContentViewComponentResult(
                new HtmlString($"<img src={(src!=""?src:JsonSerializer.Deserialize<ResultImageDog>(HttpQuery.GetResponse("https://dog.ceo/api/breeds/image/random")).message)} class='image-dog'/>")
            );
        }
    }
}
