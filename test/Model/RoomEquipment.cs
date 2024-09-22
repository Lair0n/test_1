namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomEquipment")]
    public partial class RoomEquipment
    {
        public int ID { get; set; }

        public int? RoomID { get; set; }

        public int? EquipmentID { get; set; }

        public virtual AdditionalEquipment AdditionalEquipment { get; set; }

        public virtual Rooms Rooms { get; set; }
    }
}
