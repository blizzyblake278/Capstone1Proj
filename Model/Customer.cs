using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectCustomerListWebApp.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required] //means name cannot be null
        public string CustomerName { get; set; }
        public string TimeSpan { get; set; }

        //IF YOU ADD ANY NEW PROP, YOU MUST ADD A NEW MIGRATION THRU 
        //NUGET CLI
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

    }
}
