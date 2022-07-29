using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;

namespace Pr.Pages
{
    public class RandomCharModel : PageModel
    {
        Random r=new Random();
        public char SymbolUnicode { get; set; }
        public void OnGet()
        {
            SymbolUnicode = Convert.ToChar(r.Next(-1,1)==0? r.Next(65,90):r.Next(97, 122));
        }
    }
}
