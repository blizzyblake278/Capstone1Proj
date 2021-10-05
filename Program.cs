using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;

namespace CapstoneProjectCustomerListWebApp
{
    public class Program
    {


        public static void Main(string[] args)
        {
            string subPath = @"\obj\Debug";

            Directory.Delete(subPath, true);
            

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
