using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CapstoneProjectCustomerListWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectCustomerListWebApp.Pages.CustomerList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        //getting by dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //return list of customer or ienumerable
        public IEnumerable<Customer> Customers { get; set; }


        //when using await you have to set void to async Task
        //going to DB and retrieving all customers in ienumerable
        // inside get handler
        public async Task OnGet()
        {
            Customers = await _db.Customers.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var customer = await _db.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
