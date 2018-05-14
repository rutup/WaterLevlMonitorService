using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterLevelCheckerDomain.Domain
{
  public class Configurations
  {
    public Configurations(string ioTConnectionString)
    {
      IoTConnectionString = ioTConnectionString;

    }
    public string IoTConnectionString { get; private set; }

  }
}
