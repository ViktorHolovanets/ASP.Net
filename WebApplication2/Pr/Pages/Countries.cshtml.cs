using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pr.Entity;

namespace Pr.Pages
{
    public class CountriesModel : PageModel
    {
        public List<Country> countries = new List<Country>()
        {
            new Country("Ukraine", "Kiev", 579.320),
            new Country("Country", "Kiev", 7878787),
            new Country("Andorra", "nnn",78),
        };
        public void OnGet()
        {
        }
    }
}
