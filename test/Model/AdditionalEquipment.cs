namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdditionalEquipment")]
    public partial class AdditionalEquipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdditionalEquipment()
        {
            RoomEquipment = new HashSet<RoomEquipment>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomEquipment> RoomEquipment { get; set; }
    }
}
