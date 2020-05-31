using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace ServiceMesh.Accounts
{

    class Program
    {
        static void Main(string[] args)
        {

            Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {

                     //webBuilder.ConfigureKestrel((options) =>
                     //{
                     //    //options.ListenLocalhost(9391);
                     //});

                     webBuilder.UseStartup<Startup>();
                 })
                 .Build()
                 .Run();
        }

        

    }

}




