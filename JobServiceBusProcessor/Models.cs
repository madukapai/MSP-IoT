using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServiceBusProcessor
{
    public class Models
    {
        public class SensorData
        {
            public string DeviceId { get; set; }
            public decimal Temperature { get; set; }
            public decimal Humidity { get; set; }
            public decimal PM25 { get; set; }
            public DateTime SendDateTime { get; set; }
        }
    }
}
