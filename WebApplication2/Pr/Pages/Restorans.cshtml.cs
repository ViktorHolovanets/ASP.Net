using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pr.Entity;

namespace Pr.Pages
{
    public class RestoransModel : PageModel
    {
        public List<Restoran> restorans = new List<Restoran>()
        {
            new Restoran("Restoran1", "type1", 15),
            new Restoran("name3", "type2", 15),
            new Restoran("name12323", "type3", 6),
            new Restoran("name12323", "type4", 7),
            new Restoran("name1wrewer", "type5", 157),
            new Restoran("name1erere", "type6", 8)
        };
        public void OnGet()
        {
        }
    }
}
