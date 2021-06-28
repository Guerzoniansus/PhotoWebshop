using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhotoWebshop.Pages
{
    public class OrderModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Todo: form validation, redirect back if invalid

            // Todo: Make API call to PrintAPI to actually order the thing 
            // https://portal.printapi.nl/test/docs/section/order?l=CSharp&t=NL

            return RedirectToAction("/OrderCompleteModel");
        }
    }
}
