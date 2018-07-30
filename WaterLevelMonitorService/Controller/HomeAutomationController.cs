using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WaterLevelCheckerDomain.Domain;
using WaterLevelMonitorProcessor;

namespace WaterLevelMonitorService.Controller
{
    [RoutePrefix("MyHome")]
    public class HomeAutomationController: ApiController
    {
        private readonly MessageSender _sender;
        HomeAutomationController() {
            _sender = new MessageSender();
        }
        [Route("Basic")]
        public string Get()
        {
            Console.WriteLine("adasd");
            Console.ReadLine();
            return "Working";
        }

        [Route("SupplyWater")]  
        [HttpGet]
        public string SendNotificationToDevice()
        {
           return _sender.TurnOnWater("myFirstDevice").Result.ToString();

        }

       

    }
}
