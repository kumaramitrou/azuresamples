using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace dotnetcore
{
    class Program
    {
        private const string configurationFileName = "appsettings";
        private static IConfiguration configuration;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to IoT Hub Samples.");

            // creating configurationBuilder to initialize application configuration.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{configurationFileName}.json", optional: false, reloadOnChange: true);

            // initializing configuration.
            configuration = builder.Build();

            //Gets the details of all the devices.
            GetDetails();
        }
        static void CreateDevice(string deviceId)
        {
        }
        static void GetDetails()
        {
        }
    }
}
