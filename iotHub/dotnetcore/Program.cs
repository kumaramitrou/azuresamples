using Microsoft.Azure.Devices;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace dotnetcore
{
    class Program
    {
        /// <summary>
        /// Configuration File Name
        /// </summary>
        private const string configurationFileName = "appsettings";

        /// <summary>
        /// Configuration object
        /// </summary>
        private static IConfiguration configuration;

        /// <summary>
        /// Application Starting Point
        /// </summary>
        /// <param name="args">System arguments</param>
        /// <returns>Task</returns>
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to IoT Hub Samples.");

            // creating configurationBuilder to initialize application configuration.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{configurationFileName}.json", optional: false, reloadOnChange: true);

            // initializing configuration.
            configuration = builder.Build();

            do
            {
                try
                {
                    Console.WriteLine("Enter 1 to view Details.\nEnter 2 to Create Device.\nPress Ctrl+C to terminate.");
                    var userInput = Console.ReadLine();
                    Console.Clear();
                    switch (userInput)
                    {
                        case "1":
                            //Gets the details of all the devices.
                            await GetDetails();
                            break;
                        case "2":
                            Console.WriteLine("Please Enter Device Name");
                            //Adds Device to IotHub
                            await AddDeviceAsync(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Please provide valid Input.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred {ex.Message}.");
                }
            } while (true);
        }

        /// <summary>
        /// Method to add Device to IotHub
        /// </summary>
        /// <param name="deviceId">Name of Device</param>
        /// <returns>task</returns>
        static async Task AddDeviceAsync(string deviceId)
        {
            using (var registryManager = RegistryManager.CreateFromConnectionString(configuration.GetSection("IotHub:OwnerConnectionString").Value))
            {
                try
                {
                    var device = await registryManager.AddDeviceAsync(new Device(deviceId));
                    Console.WriteLine($"Device created successfully\nDeviceId : {device.Id}\nDeviceKey : {device.Authentication.SymmetricKey.PrimaryKey}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Gets details of IoTHub
        /// </summary>
        /// <returns>task</returns>
        static async Task GetDetails()
        {
            try
            {
                using (var registryManager = RegistryManager.CreateFromConnectionString(configuration.GetSection("IotHub:OwnerConnectionString").Value))
                {
                    var deviceRegistry = await registryManager.GetRegistryStatisticsAsync();
                    Console.WriteLine($"Total Devices : {deviceRegistry.TotalDeviceCount}\nEnabled Device Count : {deviceRegistry.EnabledDeviceCount}\nDisabled Device Count : {deviceRegistry.DisabledDeviceCount}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured : {ex.Message}");
            }
        }
    }
}
