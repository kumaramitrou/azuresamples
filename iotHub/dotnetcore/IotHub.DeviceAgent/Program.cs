using System;
using System.Threading.Tasks;

namespace IotHub.DeviceAgent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to Device Agent.\n================================");
            Console.WriteLine("Enter Device Id for device to simulate.");
            var deviceId=Console.ReadLine();
            var agent = new SimulatedDevice(deviceId);
            agent.Run();
            Console.ReadLine();
        }
    }
}
