namespace IoTGateway.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IoTModel : DbContext
    {
        public IoTModel()
            : base("name=IoTModel")
        {
        }

        public virtual DbSet<IoTDevice> IoTDevices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
