using System;
using Grocery.Service.Core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Grocery.Service.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(Service.Configuration.ServiceSettings.ServiceUrl);
        }
    }
}
