using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;

namespace SendPushNotification
{
    class Program
    {
        static string connectionString = "Endpoint=sb://waterlevelsendernotification.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=ek8hGMXsteik7jMRLPWdqR3wQ1UY8WoGVQowtyEfGTM=";
        //"Endpoint=sb://rutuhomepushnotificationfirst.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=98BDO7g1YXRa5zXt63nD13k6fcL/g/46tCPBuexVUN4=";
        static string hubName = "WaterLevelSenderNotification";
        static string fireBasceConnectionString = "AAAAThvUdC0:APA91bHOTXaIdl5kN-xlFTvdw-HhViBkhsN_MotxYYAtaOL2GzbU_lL_w7qcR5ZxA0XTRflw5bX-GHv8URsXuZR0jgaJRoRFfBR1pHfMpirWOOxLfRlDWDJFd7WH_KcWpR5V3MODiGb-";
        static string senderId = "335474357293";
        static void Main(string[] args)
        {
            SendFireBaseNotification();
            Console.ReadLine();
        }
        private static async void SendTemplateNotificationAsync()
        {
            // Define the notification hub.
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);


            // Create an array of breaking news categories.
            var categories = new string[] { "World", "Politics", "Business", "Technology", "Science", "Sports" };

            // Send the notification as a template notification. All template registrations that contain
            // "messageParam" and the proper tags will receive the notifications.
            // This includes APNS, GCM, WNS, and MPNS template registrations.

            Dictionary<string, string> templateParams = new Dictionary<string, string>();

            foreach (var category in categories)
            {
                templateParams["messageParam"] = "Breaking " + category + " News!";
                await hub.SendTemplateNotificationAsync(templateParams, category);
            }
        }

        public static async void SendTemplateNotificationAsync2()
        {


            // Get the Notification Hubs credentials for the Mobile App.
            string notificationHubName = hubName;
            string notificationHubConnection = connectionString;

            // Create a new Notification Hub client.
            NotificationHubClient hub = NotificationHubClient
            .CreateClientFromConnectionString(notificationHubConnection, notificationHubName);

            // Android payload
            var androidNotificationPayload = "{ \"data\" : {\"message\":\"" + "Notification Hub test notification RUTU" + "\"}}";

            try
            {
                // Send the push notification and log the results.
                var result = await hub.SendGcmNativeNotificationAsync(androidNotificationPayload);

                // Write the success result to the logs.
                // config.Services.GetTraceWriter().Info(result.State.ToString());
            }
            catch (System.Exception ex)
            {
                // Write the failure result to the logs.
                //  //config.Services.GetTraceWriter()
                ///.Error(ex.Message, null, "Push.SendAsync Error");
            }

        }


      


        public static void Pushotification()
        {

            try
            {
                var applicationID = fireBasceConnectionString;

                // var senderId = senderId;

                //string deviceId = "euxqdp------ioIdL87abVL";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";

                tRequest.ContentType = "application/json";

                var data = new

                {
                    to = "dHWaY5ks77c:APA91bEaOGUfyky2U0tYbSrXWwHRDyzQ317wryR2cOk_gDWjeC0ZJtx8KP5CFeOy5pB-zd2r9Lwp8j3sB2bjxMCx1sEzXj-9CpGKDIX-iqcVcnWcIjkejWd984UFrVphyIOl0OOvv5VE",
                    title = "Rutu Says",
                    is_background = false,
                    message = "HelloDear",
                    image = "",
                    timestamp = DateTime.UtcNow,
                    payload = new
                    {
                        team = "Test",
                        score = "5.6"

                    }

                };
                var serializer = new JavaScriptSerializer();

                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                tRequest.ContentLength = byteArray.Length;


                using (Stream dataStream = tRequest.GetRequestStream())
                {

                    dataStream.Write(byteArray, 0, byteArray.Length);


                    using (WebResponse tResponse = tRequest.GetResponse())
                    {

                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {

                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {

                                String sResponseFromServer = tReader.ReadToEnd();

                                string str = sResponseFromServer;

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                string str = ex.Message;

            }

        }
        public static string SendFireBaseNotification()
        {
            var result = "-1";
            try
            {

                var webAddr = "https://fcm.googleapis.com/fcm/send";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=" + fireBasceConnectionString);
                httpWebRequest.Headers.Add("Sender", "335474357293");
                httpWebRequest.Method = "POST";
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    var str = new
                    {
                        to = "fNPbEnTjliE:APA91bE8u6IUNo2m_kgxWOr7tO_Tocoq_ot9ADMrK8HKUKejZ_q9e5_RyHEpGWaV7XY7VA6KblIg1L_EN92sSFe9KtkLXhFa9wvjH_wc-B7_Y28fVsWbKbYeD4QT2CCZPPnhViLzF22w",
                        //"eIZA8dgvHho:APA91bE6k1nTgADfs2oa47y_cKxI3J9T5CR5cr0hZ9vzhrFtKuUrGK2zXskni4h1K-hknYh-8Pnwjsftu0iM-v1anH-E5cToRM_wPGYlTF3Z8uP2HCu9i9GlHUGQh0k9Xuv0_unzvccm",
                        data = new
                        {
                            title = "Rutu",
                            is_background = false,
                            message = "Hello",
                            //image = "",
                            //timestamp = "2018-05-203:39:28"

                        }
                    };

                    //var str = new
                    //{
                    //    condition = "'global' in topics",
                    //    data = new
                    //    {
                    //        title = "Rutu",
                    //        is_background = false,
                    //        message = "Hello",
                    //        //image = "",
                    //        //timestamp = "2018-05-203:39:28"

                    //    }
                    //};
                    var serialiazed = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string strNJson = JsonConvert.SerializeObject(str);

                    //var strNJson = "{\"to\": \"/topics/news\", \"data\": {\"message\": \"This is a Firebase Cloud Messaging Topic Message!\",\"title\": \"rutu\"}}"; 
                    streamWriter.Write(strNJson);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

    }

}
