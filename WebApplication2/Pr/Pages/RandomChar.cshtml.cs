using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;

namespace Pr.Pages
{
    public class RandomCharModel : PageModel
    {
        public char SymbolUnicode { get; set; }
        public void OnGet()
        {
            SymbolUnicode = Convert.ToChar(new Random().Next(65,122));
        }
    }
}
