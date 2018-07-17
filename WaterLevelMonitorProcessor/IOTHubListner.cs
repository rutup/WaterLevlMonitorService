using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using SendPushNotification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WaterLevelCheckerDomain;
using WaterLevelCheckerDomain.Domain;

namespace WaterLevelMonitorProcessor
{

    public class IOTHubListner
    {
        static int notificationSentCount = 0;
        private readonly EventHubClient eventHubClient;
        private readonly Configurations configs;
        public IOTHubListner(Configurations configurations)
        {
            configs = configurations;
            eventHubClient = EventHubClient.CreateFromConnectionString(configurations.IoTConnectionString, configurations.EndPoint);
        }

        public void Start()
        {
            var tasks = new List<Task>();
            var d2cPartitions = eventHubClient.GetRuntimeInformation().PartitionIds;
            CancellationTokenSource cts = new CancellationTokenSource();
            System.Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
                Console.WriteLine("Exiting...");
            };
            foreach (string partition in d2cPartitions)
            {
                tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token));
            }
            Task.WaitAll(tasks.ToArray());

        }

        private async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        {
            var eventHubReceiver = eventHubClient.GetDefaultConsumerGroup().CreateReceiver(partition, DateTime.UtcNow);
            while (true)
            {
                if (ct.IsCancellationRequested) break;
                EventData eventData = await eventHubReceiver.ReceiveAsync();
                if (eventData == null) continue;

                string data = Encoding.UTF8.GetString(eventData.GetBytes());
                IOTMessageFormat message =  JsonConvert.DeserializeObject<IOTMessageFormat>(data);
                // bool isAlert = Convert.ToBoolean(eventData.Properties["waterAlert"]);
                if (message.isDry && notificationSentCount < 5)
                {
                    MyNotification.SendFireBaseNotification(configs.FireBaseConnectionString, message.message);
                    notificationSentCount++;
                }
                else {
                    MyNotification.SendFireBaseNotification(configs.FireBaseConnectionString, message.message);
                }
                Console.WriteLine("Message received. Partition: {0} Data: '{1}'", partition, data);

            }
        }

    }
}
