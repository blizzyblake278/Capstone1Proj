using System;
using System.ComponentModel.DataAnnotations;


namespace CapstoneProjectCustomerListWebApp.CustomerList
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

        public DateTime TimeStamp { get; set; }
    }
}
