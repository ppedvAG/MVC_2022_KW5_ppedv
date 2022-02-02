using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultMVCNET5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1.) //5.) Build (ServiceCollection wird gebuildet)
            CreateHostBuilder(args).Build().Run(); //7.) 
        }


        //2.)
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //3.) Gehe in Startup-Klasse
                });
        //Lambdas Expressions -> Prozendualer Ansatz wäre einfacher zu lesen und zu verstehen 

    }
}
