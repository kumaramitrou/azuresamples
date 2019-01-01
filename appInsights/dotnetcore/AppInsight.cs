using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace dotnetcore
{
    public class AppInsight
    {
        private IConfiguration configuration;

        public AppInsight(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Run()
        {
            Console.WriteLine("Printing Appsettings.json");
            Console.WriteLine("ConnectionStrings:Name :- "+configuration["ConnectionStrings:Name"]);
            Console.WriteLine("Inside AppInsight Class.");
            Console.ReadLine();
        }
    }
}