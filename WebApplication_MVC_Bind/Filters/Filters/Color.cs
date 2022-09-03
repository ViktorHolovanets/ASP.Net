using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Filters.Filters
{
   public enum Colors
    {
        red,
        blue,
        tomato, 
        yellow,
        green
    }
    public class Color : Attribute, IActionFilter
    {
        public Color( Colors color)
        {
            this.color = color;
        }
        Colors color;
        public void OnActionExecuted(ActionExecutedContext context)
        {           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var viewBag = (context.Controller as Controller).ViewBag;
            viewBag.Color = color;
        }
    }
}
