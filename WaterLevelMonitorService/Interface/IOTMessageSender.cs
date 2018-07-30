using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace WaterLevelMonitorService.Interface
{
    public class IOTMessageSender
    {
        readonly string connectionString = "";
        readonly ServiceClient serviceClient;
        IOTMessageSender(string conn)
        {
            connectionString = conn;
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }

        private async Task SendCloudToDeviceMessageAsync()
        {
            var commandMessage = new Message(Encoding.ASCII.GetBytes("Cloud to device message."));
            await serviceClient.SendAsync("myFirstDevice", commandMessage);
        }


    }
}
