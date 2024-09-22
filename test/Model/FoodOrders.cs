namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoodOrders
    {
        public int ID { get; set; }

        public int? GuestID { get; set; }

        public int? MenuID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? StatusID { get; set; }

        public virtual Guests Guests { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Statuses Statuses { get; set; }
    }
}
