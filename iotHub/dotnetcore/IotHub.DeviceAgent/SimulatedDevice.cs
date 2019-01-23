using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IotHub.DeviceAgent
{
    public class SimulatedDevice
    {
        private string deviceId;

        public SimulatedDevice(string deviceId)
        {
            this.deviceId = deviceId;
        }

        public async Task Run()
        {
            DeviceClient deviceClient = new DeviceClient();//DeviceClient("aodnf");
            deviceClient.
        }
    }
}
