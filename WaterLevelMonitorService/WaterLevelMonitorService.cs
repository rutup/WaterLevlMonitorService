using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WaterLevelCheckerDomain.Domain;
using WaterLevelMonitorProcessor;

namespace WaterLevelMonitorService
{
    public partial class WaterLevelMonitorService : ServiceBase
    {
        private IOTHubListner _listner;
        string WebAPIUrl = "http://localhost:90";
        public WaterLevelMonitorService()
        {
            InitializeComponent();
        }


       public void Ondebug() {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            var config = new Configurations(ConfigurationManager.AppSettings["IOTHubConnectionString"]
                , ConfigurationManager.AppSettings["FireBaseConnectionString"]
                , ConfigurationManager.AppSettings["EndPoint"]
                , ConfigurationManager.AppSettings["PushNotificationSenderId"]
                , ConfigurationManager.AppSettings["RegisteredDeviceForPushNotification"]
                );

            //_listner = new IOTHubListner(config);
            //_listner.Start();
          
            WebApp.Start<MyApiHost>(WebAPIUrl);

#if debug

#endif
        }

        protected override void OnStop()
        {
        }
    }
}
