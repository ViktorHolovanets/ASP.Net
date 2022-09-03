using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Filters.Components
{
    [ViewComponent]
    public class DivBackground
    {
        public IViewComponentResult Invoke(string color= "white")
        {
            return new HtmlContentViewComponentResult(
                new HtmlString($"<div class='row' style='background-color:{color}'>" +
                $"<div class='col w-100 h-100 vh-100'></ div > " +
                $"</div>")
            );
        }
    }
}
