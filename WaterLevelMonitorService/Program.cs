using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaterLevelMonitorService
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new WaterLevelMonitorService()
            //};
            //ServiceBase.Run(ServicesToRun);
            //WaterLevelMonitorService w = new WaterLevelMonitorService();
            WebApp.Start<MyApiHost>("http://localhost:9001");
            while (true)
            {
               
                //w.Ondebug();
                Thread.Sleep(5000);
            }
           
            
    }
  }
}
