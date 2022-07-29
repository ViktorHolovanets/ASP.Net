using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pr.Entity;

namespace Pr.Pages
{
    public class ReastaranInfoModel : PageModel
    {
        public Restoran restoran { get; set; }

        public void OnGet(string name, string type,int n)
        {
            restoran=new Restoran(name,type,n);
        }
    }
}
