using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoTGateway.Models
{
    public class SensorModel
    {
        public string DeviceId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal PM25 { get; set; }
        public DateTime SendDateTime { get; set; }
    }
}