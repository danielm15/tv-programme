using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TVP.Repositories.Implementations;
using TVP.Models.Entities;

namespace TVP.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Debug.WriteLine("TestTest");
            ApiDataCollector dataCollector = new ApiDataCollector();

            var test = await dataCollector.GetRUVProgramme();
            Debug.WriteLine(test.FirstOrDefault().title);

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
