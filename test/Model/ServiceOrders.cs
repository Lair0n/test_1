namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceOrders
    {
        public int ID { get; set; }

        public int? GuestID { get; set; }

        public int? ServiceID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? StatusID { get; set; }

        public virtual Guests Guests { get; set; }

        public virtual Service Service { get; set; }

        public virtual Statuses Statuses { get; set; }
    }
}
