using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterLevelCheckerDomain.Domain
{
    public class Configurations
    {
        public Configurations(string ioTConnectionString, string pushConnectionString, string endPoint, string pushSenderId,string deviceKey)
        {
            IoTConnectionString = ioTConnectionString;
            FireBaseConnectionString = pushConnectionString;
            EndPoint = endPoint;
            PushNotificationSenderId = pushSenderId;
            SpecificDeviceKey = deviceKey;

        }
        public string IoTConnectionString { get; private set; }
        public string FireBaseConnectionString { get; private set; }
        public string EndPoint { get; private set; }
        public string PushNotificationSenderId { get; private set; }
        public string SpecificDeviceKey { get; private set; }
        

    }
}
