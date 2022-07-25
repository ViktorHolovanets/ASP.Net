using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class Task2_HelloWordModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet(string str)
        {
            Message = str ?? "Hello,Word";
        }
    }
}
