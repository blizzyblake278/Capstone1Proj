using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProjectCustomerListWebApp.CustomerList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneProjectCustomerListWebApp.Pages.CustomerList
{//Only display textbox so user can enter customer name and timespan
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }


        public void OnGet()
        {



        }

        // post handler, always starts with On
        //can bind property above so you don't have to declare
        // an obj in the post handler below
        public async Task<IActionResult> OnPost()
        {
            //validation of input on server side
            if (ModelState.IsValid)
            {
                // added to queue
                await _db.Customers.AddAsync(Customer);
                await _db.SaveChangesAsync(); //pushed to db once saved

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
