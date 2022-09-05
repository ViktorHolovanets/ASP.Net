using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class WriteCookie : Attribute, IResourceFilter
    {
        string _cookieKey;
        string _cookieValue;
        public WriteCookie(string cookieKey, string cookieValue)
        {
            _cookieKey = cookieKey;
            _cookieValue = cookieValue;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var r = context.HttpContext.Request.Form["cate"];
            
            context.HttpContext.Response.Cookies.Append(_cookieKey, _cookieValue);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }
    }
}
