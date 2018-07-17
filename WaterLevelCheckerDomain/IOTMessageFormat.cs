using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterLevelCheckerDomain
{
    [Serializable]
    public class IOTMessageFormat
    {
        public string deviceId { get; set; }
        public bool isDry { get; set; }
        public string message { get; set; }
    }
}
