namespace IoTGateway.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IoTDevice
    {
        [Key]
        [StringLength(50)]
        public string DeviceId { get; set; }

        public string DeviceKey { get; set; }
    }
}
