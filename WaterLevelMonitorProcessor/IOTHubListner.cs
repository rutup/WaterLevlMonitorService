using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterLevelCheckerDomain.Domain;

namespace WaterLevelMonitorProcessor
{ 
  public class IOTHubListner
  {
    private readonly Configurations configs;
    public IOTHubListner(Configurations configurations)
    {
      configs = configurations;     
    }

   // public async void Start()
   // {
      //var options = new EventProcessorOptions();
     // options.ExceptionReceived += (sender, e) => { Console.WriteLine(e.Exception); };

    //  await _eventProcessorHost.RegisterIOTHubProcessorFactoryAsync(new IOTProcessorFactory(configs));
         
  //  }
  }
}
