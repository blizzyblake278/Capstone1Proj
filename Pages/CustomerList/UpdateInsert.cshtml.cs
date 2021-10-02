using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProjectCustomerListWebApp.CustomerList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectCustomerListWebApp.Pages.CustomerList
{
    public class UpdateInsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpdateInsertModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Customer Customer { get; set; }

        //id is possible may be null, so use nullable int so id can be null
        public async Task<IActionResult> OnGet(int? id)
        {
            //create
            Customer = new Customer();
            if (id == null)
            {
                return Page();
            }

            //update
            Customer = await _db.Customers.FirstOrDefaultAsync(i => i.Id == id);
            if (Customer == null)
            {

                return NotFound();
            }

            Customer = await _db.Customers.FindAsync(id);
            return Page();

        }


        public async Task<IActionResult> OnPost()
        {
            //updates all info of customer
            if (ModelState.IsValid)
            {
                if (Customer.Id == 0)
                {
                    _db.Customers.Add(Customer);
                }
                else
                {
                    _db.Customers.Update(Customer);
                }

                //**Below can be used when updating a few lines of info, from edit.cshtml**
                //var customerFromDb = await _db.Customers.FindAsync(Customer.Id);
                //customerFromDb.CustomerName = Customer.CustomerName;
                //customerFromDb.TimeSpan = Customer.TimeSpan;
                //customerFromDb.TimeStamp = Customer.TimeStamp;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            return RedirectToPage();

        }
    }
}
