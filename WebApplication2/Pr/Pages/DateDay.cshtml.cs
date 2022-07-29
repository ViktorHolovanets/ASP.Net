using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System;

namespace Pr.Pages
{
    public class DateDayModel : PageModel
    {
        public int day { get; set; }
        public void OnGet()
        {
            day = DateAndTime.Now.DayOfYear;
        }
    }
}
