﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using WaterLevelCheckerDomain;
using WaterLevelCheckerDomain.Domain;

namespace WaterLevelMonitorProcessor
{
    public class MessageSender
    {
        private readonly ServiceClient _serviceClient;
        public MessageSender()
        {           
            _serviceClient = ServiceClient.CreateFromConnectionString(ConfigurationManager.AppSettings["IOTHubConnectionString"]);
        }

        public async Task SendBeaconMessage(string deviceName, IOTMessageFormat message)
        {
            var messageString = JsonConvert.SerializeObject(message);
            var commandMessage = new Message(Encoding.ASCII.GetBytes(messageString));
            commandMessage.MessageId = Guid.NewGuid().ToString();
            commandMessage.Ack = DeliveryAcknowledgement.Full;
            await _serviceClient.SendAsync(deviceName, commandMessage);
        }

    }
}
