using System.Threading.Tasks;
using CapstoneProjectCustomerListWebApp.CustomerList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneProjectCustomerListWebApp.Pages.CustomerList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Customer Customer { get; set; }

        public async Task OnGet(int id)
        {
            Customer = await _db.Customers.FindAsync(id);
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Customer obj from line 23, retrieve is and pass the id. 
                //make sure you have ID set in cshtml file as well as shown on line 11 of edit.cshtml
                var customerFromDb = await _db.Customers.FindAsync(Customer.Id);
                customerFromDb.CustomerName = Customer.CustomerName;
                customerFromDb.TimeSpan = Customer.TimeSpan;
                customerFromDb.TimeStamp = Customer.TimeStamp;

                await _db.SaveChangesAsync();
             
                return RedirectToPage("Index");

            }
            return RedirectToPage();

        }
    }
}
