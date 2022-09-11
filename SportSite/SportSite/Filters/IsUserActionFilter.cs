using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SportSite.Filters
{
    public class IsUserActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var viewBag = (context.Controller as Controller).ViewBag;
            viewBag.IsUser = context.HttpContext.Request.Cookies.ContainsKey("id");
        }
    }
}
