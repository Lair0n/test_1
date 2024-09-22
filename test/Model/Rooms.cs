namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rooms()
        {
            Reservations = new HashSet<Reservations>();
            RoomEquipment = new HashSet<RoomEquipment>();
        }

        public int ID { get; set; }

        public int? RoomNumber { get; set; }

        public int? TypeID { get; set; }

        public decimal? Price { get; set; }

        public bool? Availability { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservations> Reservations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomEquipment> RoomEquipment { get; set; }

        public virtual RoomTypes RoomTypes { get; set; }
    }
}
