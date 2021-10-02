using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProjectCustomerListWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectCustomerListWebApp.Controllers
{
    //Makes sure api controller is the customer controller
    // and this is the route the api will use
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        //gets information from api for dbt
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data = await _db.Customers.ToListAsync()});
        }

        //once info from api is found can delete db entry
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var customerFromDb = await _db.Customers.FirstOrDefaultAsync(i => i.Id == id);
            if (customerFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            _db.Customers.Remove(customerFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful!" });
        }
    }
}
