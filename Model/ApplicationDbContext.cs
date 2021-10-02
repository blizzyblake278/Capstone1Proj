﻿using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectCustomerListWebApp.Model
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
