namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservations
    {
        public int ID { get; set; }

        public int? GuestID { get; set; }

        public int? RoomID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CheckInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CheckOutDate { get; set; }

        public int? StatusID { get; set; }

        public virtual Guests Guests { get; set; }

        public virtual Statuses Statuses { get; set; }

        public virtual Rooms Rooms { get; set; }
    }
}
