using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendPushNotification
{
    public class MyNotification
    {
        public static string SendFireBaseNotification(string fireBasceConnectionString,string msg)
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
                        data = new
                        {
                            title = "Rutu",
                            is_background = false,
                            message = msg,
                            //image = "",
                            //timestamp = "2018-05-203:39:28"

                        }
                    };


                    var serialiazed = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string strNJson = JsonConvert.SerializeObject(str);

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
