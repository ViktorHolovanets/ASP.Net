using Filters.Models.DB;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class GlobalLogFilter : Attribute, IActionFilter
    {
        Db db;
        public GlobalLogFilter(Db context)
        {
            db = context;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            Visitor visitor = new Visitor()
            {
                Ip = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                Host = request.Host.Value,
                Url = request.Path,
                Date = DateTime.Now
            };
            db.Visitors.Add(visitor);        
        }
    }
}
