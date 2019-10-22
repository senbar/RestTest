using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RestTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string portString; 
            do
            {
                Console.WriteLine("Port: ");
                portString = Console.ReadLine();
            } while(!Int32.TryParse(portString, out int _));
             
            CreateHostBuilder(args, portString)
                .Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args, string port) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseUrls(urls: "https://localhost:" + port);
                });
    }
}
