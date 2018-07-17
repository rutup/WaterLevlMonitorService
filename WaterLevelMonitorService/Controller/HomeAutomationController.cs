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
        [Route("Health")]
        public string Get()
        {
            return "Working";
        }

        [Route("TurnOn")]
        [Route("TurnOff")]
        [HttpGet]
        public string SendNotificationToDevice()
        {
            return "Working";
        }

       

    }
}
